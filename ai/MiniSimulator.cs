using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HREngine.Bots
{
    public class MiniSimulator
    {
        //#####################################################################################################################
        private int maxdeep = 6;
        private int maxwide = 10;
        private int totalboards = 50;
        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;

        private bool printNormalstuff;
        private bool print;

        List<Playfield> posmoves = new List<Playfield>(7000);
        List<Playfield> bestoldDuplicates = new List<Playfield>(7000);
        List<Playfield> twoturnfields = new List<Playfield>(500);

        List<List<Playfield>> threadresults = new List<List<Playfield>>(64);
        private int dirtyTwoTurnSim = 256;

        public Action bestmove;
        public float bestmoveValue;
        private float bestoldval = -20000000;
        public Playfield bestboard = new Playfield();

        public Behavior botBase;
        private int calculated;
        private bool enoughCalculations;

        private bool isLethalCheck;
        private bool simulateSecondTurn = false;
        private bool playaround;
        private int playaroundprob = 50;
        private int playaroundprob2 = 80;

        private static readonly object threadnumberLocker = new object();
        private int threadnumberGlobal;

        Movegenerator movegen = Movegenerator.Instance;

        PenalityManager pen = PenalityManager.Instance;

        public MiniSimulator()
        {
        }

        public MiniSimulator(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void updateParams(int deep, int wide, int ttlboards)
        {
            this.maxdeep = deep;
            this.maxwide = wide;
            this.totalboards = ttlboards;
        }

        public void setPrintingstuff(bool sp)
        {
            this.printNormalstuff = sp;
        }

        public void setSecondTurnSimu(bool sts, int amount)
        {
            //this.simulateSecondTurn = sts;
            this.dirtyTwoTurnSim = amount;
        }

        public int getSecondTurnSimu()
        {
            return this.dirtyTwoTurnSim;
        }

        public void setPlayAround(bool spa, int pprob, int pprob2)
        {
            this.playaround = spa;
            this.playaroundprob = pprob;
            this.playaroundprob2 = pprob2;
        }

        private void addToPosmoves(Playfield pf)
        {
            if (pf.ownHero.Hp <= 0)
            {
                return;
            }

            this.posmoves.Add(pf);
            if (this.totalboards >= 1)
            {
                this.calculated++;
            }
        }

        public float doallmoves(Playfield playf)
        {
            this.print = playf.print;
            this.isLethalCheck = playf.isLethalCheck;
            this.enoughCalculations = false;
            this.botBase = Ai.Instance.botBase;
            this.posmoves.Clear();
            this.twoturnfields.Clear();
            this.addToPosmoves(playf);
            var havedonesomething = true;
            var temp = new List<Playfield>();
            var deep = 0;
            this.calculated = 0;
            Playfield bestold = null;
            this.bestoldval = -20000000;
            while (havedonesomething)
            {
                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg("ailoop");
                }

                GC.Collect();
                temp.Clear();
                temp.AddRange(this.posmoves);
                this.posmoves.Clear();
                havedonesomething = false;
                this.threadnumberGlobal = 0;

                if (this.print)
                {
                    this.startEnemyTurnSimThread(temp, 0, temp.Count);
                }
                else
                {
                    Parallel.ForEach(Partitioner.Create(0, temp.Count),
                        range =>
                        {
                            this.startEnemyTurnSimThread(temp, range.Item1, range.Item2);
                        });
                }

                foreach (var p in temp)
                {
                    if (this.totalboards > 0)
                    {
                        this.calculated += p.nextPlayfields.Count;
                    }

                    if (this.calculated <= this.totalboards)
                    {
                        this.posmoves.AddRange(p.nextPlayfields);
                        p.nextPlayfields.Clear();
                    }

                    //get the best Playfield
                    var pVal = this.botBase.getPlayfieldValue(p);
                    if (pVal > this.bestoldval)
                    {
                        this.bestoldval = pVal;
                        bestold = p;
                        this.bestoldDuplicates.Clear();
                    }
                    else if (pVal == this.bestoldval)
                    {
                        this.bestoldDuplicates.Add(p);
                    }
                }

                if (this.isLethalCheck && this.bestoldval >= 10000)
                {
                    this.posmoves.Clear();
                }

                if (this.posmoves.Count > 0)
                {
                    havedonesomething = true;
                }

                if (this.printNormalstuff)
                {
                    var donec = 0;
                    foreach (var p in this.posmoves)
                    {
                        if (p.complete)
                        {
                            donec++;
                        }
                    }

                    Helpfunctions.Instance.logg($"deep {deep} len {this.posmoves.Count} dones {donec}");
                }

                this.cuttingposibilities(this.isLethalCheck);

                if (this.printNormalstuff)
                {
                    Helpfunctions.Instance.logg($"cut to len {this.posmoves.Count}");
                }

                deep++;
                temp.Clear();

                if (this.calculated > this.totalboards)
                {
                    this.enoughCalculations = true;
                }

                if (deep >= this.maxdeep)
                {
                    this.enoughCalculations = true;
                }
            }

            if (this.dirtyTwoTurnSim > 0 && !this.twoturnfields.Contains(bestold))
            {
                this.twoturnfields.Add(bestold);
            }

            this.posmoves.Clear();
            this.posmoves.Add(bestold);
            this.posmoves.AddRange(this.bestoldDuplicates);

            // search the best play...........................................................
            //do dirtytwoturnsim first :D
            if (!this.isLethalCheck && this.bestoldval < 10000)
            {
                this.doDirtyTwoTurnsim();
            }

            if (this.posmoves.Count >= 1)
            {
                this.posmoves.Sort((a, b) => this.botBase.getPlayfieldValue(b).CompareTo(this.botBase.getPlayfieldValue(a)));
                var bestplay = this.posmoves[0];
                var bestval = this.botBase.getPlayfieldValue(bestplay);
                var pcount = this.posmoves.Count;
                for (var i = 1; i < pcount; i++)
                {
                    var val = this.botBase.getPlayfieldValue(this.posmoves[i]);
                    if (bestval > val)
                    {
                        break;
                    }

                    if (this.posmoves[i].cardsPlayedThisTurn > bestplay.cardsPlayedThisTurn)
                    {
                        continue;
                    }

                    if (this.posmoves[i].cardsPlayedThisTurn == bestplay.cardsPlayedThisTurn)
                    {
                        if (bestplay.optionsPlayedThisTurn > this.posmoves[i].optionsPlayedThisTurn)
                        {
                            continue;
                        }

                        if (bestplay.optionsPlayedThisTurn == this.posmoves[i].optionsPlayedThisTurn && bestplay.enemyHero.Hp <= this.posmoves[i].enemyHero.Hp)
                        {
                            continue;
                        }
                    }

                    bestplay = this.posmoves[i];
                    bestval = val;
                }

                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);
                this.bestboard.guessingHeroHP = bestplay.guessingHeroHP;
                this.bestboard.value = bestplay.value;
                this.bestboard.hashcode = bestplay.hashcode;
                this.bestoldDuplicates.Clear();
                return bestval;
            }

            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;

            return -10000;
        }


        private void startEnemyTurnSimThread(List<Playfield> source, int startIndex, int endIndex)
        {
            var threadnumber = 0;
            lock (threadnumberLocker)
            {
                threadnumber = this.threadnumberGlobal++;
                Monitor.Pulse(threadnumberLocker);
            }

            if (threadnumber > Ai.Instance.maxNumberOfThreads - 2)
            {
                threadnumber = Ai.Instance.maxNumberOfThreads - 2;
                Helpfunctions.Instance.ErrorLog("You need more threads!");
                return;
            }


            var berserk = Settings.Instance.berserkIfCanFinishNextTour;
            var printRules = Settings.Instance.printRules;

            for (var i = startIndex; i < endIndex; i++)
            {
                var p = source[i];
                if (p.complete || p.ownHero.Hp <= 0) { }
                else if (!this.enoughCalculations)
                {
                    //gernerate actions and play them!
                    var actions = this.movegen.getMoveList(p, this.usePenalityManager, this.useCutingTargets, true);

                    if (printRules > 0)
                    {
                        p.endTurnState = new Playfield(p);
                    }

                    foreach (var a in actions)
                    {
                        var pf = new Playfield(p);
                        pf.doAction(a);
                        pf.evaluatePenality += -pf.ruleWeight + RulesEngine.Instance.getRuleWeight(pf);
                        if (pf.ownHero.Hp > 0 && pf.evaluatePenality < 500)
                        {
                            p.nextPlayfields.Add(pf);
                        }
                    }
                }

                if (this.isLethalCheck)
                {
                    if (berserk > 0)
                    {
                        p.endTurn();
                        if (p.enemyHero.Hp > 0)
                        {
                            var needETS = true;
                            if (p.anzEnemyTaunt < 1)
                            {
                                foreach (var m in p.ownMinions)
                                {
                                    if (m.Ready)
                                    {
                                        needETS = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (p.anzOwnTaunt < 1)
                                {
                                    foreach (var m in p.ownMinions)
                                    {
                                        if (m.Ready)
                                        {
                                            needETS = false;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (needETS)
                            {
                                Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, this.simulateSecondTurn, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                            }
                        }
                    }

                    p.complete = true;
                }
                else
                {
                    p.endTurn();

                    if (p.enemyHero.Hp > 0)
                    {
                        Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, this.simulateSecondTurn, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                        if (p.value <= -10000)
                        {
                            var secondChance = false;
                            foreach (var a in p.playactions)
                            {
                                if (a.actionType == actionEnum.playcard)
                                {
                                    if (this.pen.cardDrawBattleCryDatabase.ContainsKey(a.card.card.CardId))
                                    {
                                        secondChance = true;
                                    }
                                }
                            }

                            if (secondChance)
                            {
                                p.value += 1500;
                            }
                        }
                    }

                    p.complete = true;
                }

                this.botBase.getPlayfieldValue(p);
            }
        }

        public void doDirtyTwoTurnsim()
        {
            if (this.dirtyTwoTurnSim == 0)
            {
                return;
            }

            this.posmoves.Clear();

            if (this.print)
            {
                this.doDirtyTwoTurnsimThread(this.twoturnfields, 0, this.twoturnfields.Count);
            }
            else
            {
                Parallel.ForEach(Partitioner.Create(0, this.twoturnfields.Count),
                    range =>
                    {
                        this.doDirtyTwoTurnsimThread(this.twoturnfields, range.Item1, range.Item2);
                    });
            }

            this.posmoves.AddRange(this.twoturnfields);
        }

        public void doDirtyTwoTurnsimThread(List<Playfield> source, int startIndex, int endIndex)
        {
            var threadnumber = Ai.Instance.maxNumberOfThreads - 2;
            if (endIndex < source.Count)
            {
                threadnumber = startIndex / (endIndex - startIndex);
            }

            //set maxwide of enemyturnsimulator's to second step (this value is higher than the maxwide in first step) 
            Ai.Instance.enemyTurnSim[threadnumber].setMaxwide(false);

            for (var i = startIndex; i < endIndex; i++)
            {
                var p = source[i];
                if (p.guessingHeroHP >= 1)
                {
                    p.doDirtyTts = p.value;
                    p.complete = false;
                    p.value = int.MinValue;
                    p.bestEnemyPlay = null;
                    Ai.Instance.enemyTurnSim[threadnumber].simulateEnemysTurn(p, true, this.playaround, false, this.playaroundprob, this.playaroundprob2);
                }

                this.botBase.getPlayfieldValue(p);
            }
        }


        public void cuttingposibilities(bool isLethalCheck)
        {
            // take the x best values
            var temp = new List<Playfield>();
            var tempDict = new Dictionary<long, Playfield>();
            this.posmoves.Sort((a, b) => this.botBase.getPlayfieldValue(b).CompareTo(this.botBase.getPlayfieldValue(a))); //want to keep the best

            if (this.useComparison)
            {
                var i = 0;
                var max = Math.Min(this.posmoves.Count, this.maxwide);

                Playfield p = null;
                for (i = 0; i < max; i++)
                {
                    p = this.posmoves[i];
                    var hash = p.GetPHash();
                    p.hashcode = hash;
                    if (!tempDict.ContainsKey(hash))
                    {
                        tempDict.Add(hash, p);
                    }
                    else if (p.evaluatePenality < tempDict[hash].evaluatePenality)
                    {
                        tempDict[hash] = p;
                    }
                }

                foreach (var d in tempDict)
                {
                    temp.Add(d.Value);
                }
            }
            else
            {
                temp.AddRange(this.posmoves);
            }

            this.posmoves.Clear();
            this.posmoves.AddRange(temp);


            //twoturnfields!
            if (this.dirtyTwoTurnSim == 0 || isLethalCheck)
            {
                return;
            }

            tempDict.Clear();
            temp.Clear();
            if (this.bestoldval >= 10000)
            {
                return;
            }

            foreach (var p in this.twoturnfields)
            {
                tempDict.Add(p.hashcode, p);
            }

            this.posmoves.Sort((a, b) => this.botBase.getPlayfieldValue(b).CompareTo(this.botBase.getPlayfieldValue(a)));

            var maxTts = Math.Min(this.posmoves.Count, this.dirtyTwoTurnSim);
            for (var i = 0; i < maxTts; i++)
            {
                if (!tempDict.ContainsKey(this.posmoves[i].hashcode))
                {
                    temp.Add(this.posmoves[i]);
                }
            }

            this.twoturnfields.Sort((a, b) => this.botBase.getPlayfieldValue(b).CompareTo(this.botBase.getPlayfieldValue(a)));
            temp.AddRange(this.twoturnfields.GetRange(0, Math.Min(this.dirtyTwoTurnSim, this.twoturnfields.Count)));
            this.twoturnfields.Clear();
            this.twoturnfields.AddRange(temp);
        }

        public void printPosmoves()
        {
            var i = 0;
            foreach (var p in this.posmoves)
            {
                p.printBoard();
                i++;
                if (i >= 200)
                {
                    break;
                }
            }
        }
    }
}