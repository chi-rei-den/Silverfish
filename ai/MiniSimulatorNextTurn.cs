using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    public class MiniSimulatorNextTurn
    {
        //#####################################################################################################################
        //public int maxdeep = 6;
        //public int maxwide = 10;
        //public int totalboards = 50;

        public int thread = 0;

        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;

        List<Playfield> posmoves = new List<Playfield>(7000);

        public Action bestmove;
        public float bestmoveValue;
        public Playfield bestboard = new Playfield();

        public Behavior botBase;
        private int calculated;

        private bool simulateSecondTurn = false;

        Movegenerator movegen = Movegenerator.Instance;


        private void startEnemyTurnSim(Playfield p, bool simulateTwoTurns, bool print, bool playaround, int playaroundprob, int playaroundprob2)
        {
            if (p.guessingHeroHP >= 1)
            {
                Ai.Instance.enemySecondTurnSim[this.thread].simulateEnemysTurn(p, simulateTwoTurns, playaround, print, playaroundprob, playaroundprob2);
            }

            p.complete = true;
        }

        public float doallmoves(Playfield playf, bool print = false)
        {
            //todo only one time!
            var isLethalCheck = playf.isLethalCheck;
            var totalboards = Settings.Instance.nextTurnTotalBoards;
            var maxwide = Settings.Instance.nextTurnMaxWide;
            var maxdeep = Settings.Instance.nextTurnDeep;
            var playaround = Settings.Instance.playaround;
            var playaroundprob = Settings.Instance.playaroundprob;
            var playaroundprob2 = Settings.Instance.playaroundprob2;

            this.botBase = Ai.Instance.botBase;
            this.posmoves.Clear();
            this.posmoves.Add(new Playfield(playf));
            var havedonesomething = true;
            var temp = new List<Playfield>();
            var deep = 0;
            this.calculated = 0;
            Playfield bestold = null;
            float bestoldval = -20000000;
            while (havedonesomething)
            {
                //GC.Collect();
                temp.Clear();
                temp.AddRange(this.posmoves);
                havedonesomething = false;
                foreach (var p in temp)
                {
                    if (p.complete || p.ownHero.Hp <= 0)
                    {
                        continue;
                    }

                    var actions = this.movegen.getMoveList(p, this.usePenalityManager, this.useCutingTargets, true);
                    foreach (var a in actions)
                    {
                        havedonesomething = true;
                        var pf = new Playfield(p);
                        pf.doAction(a);
                        if (pf.ownHero.Hp > 0)
                        {
                            this.posmoves.Add(pf);
                        }

                        if (totalboards > 0)
                        {
                            this.calculated++;
                        }
                    }


                    p.endTurn();

                    if (!isLethalCheck)
                    {
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false, playaround, playaroundprob, playaroundprob2);
                    }

                    //sort stupid stuff ouf

                    if (this.botBase.getPlayfieldValue(p) > bestoldval)
                    {
                        bestoldval = this.botBase.getPlayfieldValue(p);
                        bestold = p;
                    }

                    this.posmoves.Remove(p);

                    if (this.calculated > totalboards)
                    {
                        break;
                    }
                }

                this.cuttingposibilities(maxwide);

                deep++;

                if (this.calculated > totalboards)
                {
                    break;
                }

                if (deep >= maxdeep)
                {
                    break;
                }
            }

            this.posmoves.Add(bestold);
            foreach (var p in this.posmoves)
            {
                if (!p.complete)
                {
                    p.endTurn();
                    if (!isLethalCheck)
                    {
                        this.startEnemyTurnSim(p, this.simulateSecondTurn, false, playaround, playaroundprob, playaroundprob2);
                    }
                }
            }
            // find best

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

                    if (bestplay.playactions.Count <= this.posmoves[i].playactions.Count)
                    {
                        continue; //priority to the minimum acts
                    }

                    bestplay = this.posmoves[i];
                    bestval = val;
                }

                this.bestmove = bestplay.getNextAction();
                this.bestmoveValue = bestval;
                this.bestboard = new Playfield(bestplay);
                return bestval;
            }

            this.bestmove = null;
            this.bestmoveValue = -100000;
            this.bestboard = playf;
            return -10000;
        }

        public void cuttingposibilities(int maxwide)
        {
            // take the x best values
            var temp = new List<Playfield>();
            var tempDict = new Dictionary<long, Playfield>();
            this.posmoves.Sort((a, b) => -this.botBase.getPlayfieldValue(a).CompareTo(this.botBase.getPlayfieldValue(b))); //want to keep the best

            if (this.useComparison)
            {
                var i = 0;
                var max = Math.Min(this.posmoves.Count, maxwide);

                Playfield p = null;
                //foreach (Playfield p in posmoves)
                for (i = 0; i < max; i++)
                {
                    p = this.posmoves[i];
                    var hash = p.GetPHash();
                    p.hashcode = hash;
                    if (!tempDict.ContainsKey(hash))
                    {
                        tempDict.Add(hash, p);
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
            this.posmoves.AddRange(temp.GetRange(0, Math.Min(maxwide, temp.Count)));
        }

        public void printPosmoves()
        {
            foreach (var p in this.posmoves)
            {
                p.printBoard();
            }
        }
    }
}