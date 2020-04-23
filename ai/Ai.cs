using System;
using System.Collections.Generic;
using HearthDb;

namespace HREngine.Bots
{
    public class Ai
    {
        private int maxdeep = 12;

        public int maxwide = 3000;

        //public int playaroundprob = 40;
        public int playaroundprob2 = 80;
        public int maxNumberOfThreads = 100; //don't change manually, because it changes automatically

        private bool usePenalityManager = true;
        private bool useCutingTargets = true;
        private bool dontRecalc = true;
        private bool useLethalCheck = true;
        private bool useComparison = true;
        public Playfield bestplay = new Playfield();


        public int lethalMissing = 30; //RR

        public MiniSimulator mainTurnSimulator;
        public List<EnemyTurnSimulator> enemyTurnSim = new List<EnemyTurnSimulator>();
        public List<MiniSimulatorNextTurn> nextTurnSimulator = new List<MiniSimulatorNextTurn>();
        public List<EnemyTurnSimulator> enemySecondTurnSim = new List<EnemyTurnSimulator>();

        public string currentCalculatedBoard = "1";

        PenalityManager penman = PenalityManager.Instance;
        Settings settings = Settings.Instance;

        List<Playfield> posmoves = new List<Playfield>(7000);

        Hrtprozis hp = Hrtprozis.Instance;
        Handmanager hm = Handmanager.Instance;
        Helpfunctions help = Helpfunctions.Instance;

        public Action bestmove;
        public float bestmoveValue;
        public Playfield nextMoveGuess = new Playfield();
        public Behavior botBase;

        public List<Action> bestActions = new List<Action>();

        public bool secondturnsim;

        //public int secondTurnAmount = 256;
        public bool playaround = false;

        private static Ai instance;

        public static Ai Instance
        {
            get
            {
                return instance ?? (instance = new Ai());
            }
        }

        private Ai()
        {
            this.nextMoveGuess = new Playfield {mana = -100};

            this.mainTurnSimulator = new MiniSimulator(this.maxdeep, this.maxwide, 0); // 0 for unlimited
            this.mainTurnSimulator.setPrintingstuff(true);

            for (var i = 0; i < this.maxNumberOfThreads; i++)
            {
                this.nextTurnSimulator.Add(new MiniSimulatorNextTurn());
                this.enemyTurnSim.Add(new EnemyTurnSimulator());
                this.enemySecondTurnSim.Add(new EnemyTurnSimulator());

                this.nextTurnSimulator[i].thread = i;
                this.enemyTurnSim[i].thread = i;
                this.enemySecondTurnSim[i].thread = i;
            }
        }

        public void setMaxWide(int mw)
        {
            this.maxwide = mw;
            if (this.maxwide <= 100)
            {
                this.maxwide = 100;
            }

            this.mainTurnSimulator.updateParams(this.maxdeep, this.maxwide, 0);
        }

        public void setTwoTurnSimulation(bool stts, int amount)
        {
            this.mainTurnSimulator.setSecondTurnSimu(stts, amount);
            this.secondturnsim = stts;
            this.settings.secondTurnAmount = amount;
        }

        public void updateTwoTurnSim()
        {
            this.mainTurnSimulator.setSecondTurnSimu(this.settings.simulateEnemysTurn, this.settings.secondTurnAmount);
        }

        public void setPlayAround()
        {
            this.mainTurnSimulator.setPlayAround(this.settings.playaround, this.settings.playaroundprob, this.settings.playaroundprob2);
        }

        private void doallmoves(bool test, bool isLethalCheck)
        {
            //set maxwide to the value for the first-turn-sim.
            foreach (var ets in this.enemyTurnSim)
            {
                ets.setMaxwide(true);
            }

            foreach (var ets in this.enemySecondTurnSim)
            {
                ets.setMaxwide(true);
            }

            //if (isLethalCheck) this.posmoves[0].enemySecretList.Clear();
            this.posmoves[0].isLethalCheck = isLethalCheck;
            this.mainTurnSimulator.doallmoves(this.posmoves[0]);

            this.bestplay = this.mainTurnSimulator.bestboard;
            var bestval = this.mainTurnSimulator.bestmoveValue;

            this.help.loggonoff(true);
            this.help.logg("-------------------------------------");
            if (this.bestplay.ruleWeight != 0)
            {
                this.help.logg($"ruleWeight {this.bestplay.ruleWeight * -1}");
            }

            if (this.settings.printRules > 0)
            {
                var rulesStr = this.bestplay.rulesUsed.Split('@');
                foreach (var rs in rulesStr)
                {
                    if (rs == "")
                    {
                        continue;
                    }

                    this.help.logg($"rule: {rs}");
                }
            }

            this.help.logg($"value of best board {bestval}");

            this.bestActions.Clear();
            this.bestmove = null;
            var an = new ActionNormalizer();
            //an.checkLostActions(bestplay, isLethalCheck);
            if (this.settings.adjustActions > 0)
            {
                an.adjustActions(this.bestplay, isLethalCheck);
            }

            foreach (var a in this.bestplay.playactions)
            {
                this.bestActions.Add(new Action(a));
                a.print();
            }

            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }

            this.bestmoveValue = bestval;

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                this.nextMoveGuess = new Playfield();

                this.nextMoveGuess.doAction(this.bestmove);
            }
            else
            {
                this.nextMoveGuess.mana = -100;
            }

            if (isLethalCheck)
            {
                this.lethalMissing = this.bestplay.enemyHero.armor + this.bestplay.enemyHero.Hp; //RR
                this.help.logg($"missing dmg to lethal {this.lethalMissing}");
            }
        }

        public void doNextCalcedMove()
        {
            this.help.logg("noRecalcNeeded!!!-----------------------------------");
            //this.bestboard.printActions();

            this.bestmove = null;
            if (this.bestActions.Count >= 1)
            {
                this.bestmove = this.bestActions[0];
                this.bestActions.RemoveAt(0);
            }

            if (this.nextMoveGuess == null)
            {
                this.nextMoveGuess = new Playfield();
            }
            else
            {
                Silverfish.Instance.updateCThunInfo(this.nextMoveGuess.anzOgOwnCThunAngrBonus, this.nextMoveGuess.anzOgOwnCThunHpBonus, this.nextMoveGuess.anzOgOwnCThunTaunt);
            }

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                //this.nextMoveGuess = new Playfield();
                Helpfunctions.Instance.logg("nmgsim-");
                try
                {
                    this.nextMoveGuess.doAction(this.bestmove);
                    this.bestmove = this.nextMoveGuess.playactions[this.nextMoveGuess.playactions.Count - 1];
                }
                catch (Exception ex)
                {
                    Helpfunctions.Instance.logg("Message ---");
                    Helpfunctions.Instance.logg($"Message ---{ex.Message}");
                    Helpfunctions.Instance.logg($"Source ---{ex.Source}");
                    Helpfunctions.Instance.logg($"StackTrace ---{ex.StackTrace}");
                    Helpfunctions.Instance.logg($"TargetSite ---\n{{0}}{ex.TargetSite}");
                }

                Helpfunctions.Instance.logg("nmgsime-");
            }
            else
            {
                //Helpfunctions.Instance.logg("nd trn");
                this.nextMoveGuess.mana = -100;
                var twilightelderBonus = 0;
                foreach (var m in this.nextMoveGuess.ownMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.TwilightElder && !m.silenced)
                    {
                        twilightelderBonus++;
                    }
                }

                if (twilightelderBonus > 0)
                {
                    Silverfish.Instance.updateCThunInfo(this.nextMoveGuess.anzOgOwnCThunAngrBonus + twilightelderBonus, this.nextMoveGuess.anzOgOwnCThunHpBonus + twilightelderBonus, this.nextMoveGuess.anzOgOwnCThunTaunt);
                }
            }
        }

        public void dosomethingclever(Behavior bbase)
        {
            //return;
            //turncheck
            //help.moveMouse(950,750);
            //help.Screenshot();
            this.botBase = bbase;
            this.hp.updatePositions();

            this.posmoves.Clear();
            this.posmoves.Add(new Playfield());

            this.help.loggonoff(false);
            //do we need to recalc?
            this.help.logg("recalc-check###########");
            if (this.dontRecalc && this.posmoves[0].isEqual(this.nextMoveGuess, true))
            {
                this.doNextCalcedMove();
            }
            else
            {
                this.help.logg("Leathal-check###########");
                this.bestmoveValue = -1000000;
                var strt = DateTime.Now;
                if (this.useLethalCheck)
                {
                    strt = DateTime.Now;
                    this.doallmoves(false, true);
                    this.help.logg($"calculated {(DateTime.Now - strt).TotalSeconds}");
                }

                if (this.bestmoveValue < 10000)
                {
                    this.posmoves.Clear();
                    this.posmoves.Add(new Playfield());
                    this.help.logg("no lethal, do something random######");
                    strt = DateTime.Now;
                    this.doallmoves(false, false);
                    this.help.logg($"calculated {(DateTime.Now - strt).TotalSeconds}");
                }
            }


            //help.logging(true);
        }


        public List<double> autoTester(bool printstuff, string data = "", int mode = 0) //-mode: 0-all, 1-lethalcheck, 2-normal
        {
            var retval = new List<double>();
            double calcTime = 0;
            this.help.logg("simulating board ");

            var bt = new BoardTester(data);
            if (!bt.datareaded)
            {
                return retval;
            }

            this.hp.printHero();
            this.hp.printOwnMinions();
            this.hp.printEnemyMinions();
            this.hm.printcards();
            //calculate the stuff
            this.posmoves.Clear();
            var pMain = new Playfield();
            pMain.print = printstuff;
            this.posmoves.Add(pMain);
            foreach (var p in this.posmoves)
            {
                p.printBoard();
            }

            this.help.logg($"ownminionscount {this.posmoves[0].ownMinions.Count}");
            this.help.logg($"owncardscount {this.posmoves[0].owncards.Count}");

            foreach (var item in this.posmoves[0].owncards)
            {
                this.help.logg(
                    $"card {item.card} is playable :{item.canplayCard(this.posmoves[0], true)} cost/mana: {item.manacost}/{this.posmoves[0].mana}");
            }

            this.help.logg(
                $"ability {this.posmoves[0].ownHeroAblility.card} is playable :{this.posmoves[0].ownHeroAblility.card.canplayCard(this.posmoves[0], 2, true)} cost/mana: {this.posmoves[0].ownHeroAblility.card.getManaCost(this.posmoves[0], 2)}/{this.posmoves[0].mana}");

            var strt = DateTime.Now;
            // lethalcheck
            if (mode == 0 || mode == 1)
            {
                this.doallmoves(false, true);
                calcTime = (DateTime.Now - strt).TotalSeconds;
                this.help.logg($"calculated {calcTime}");
                retval.Add(calcTime);
            }

            if (Settings.Instance.berserkIfCanFinishNextTour > 0 && this.bestmoveValue > 5000)
            {
            }
            else if (this.bestmoveValue < 10000)
            {
                // normal
                if (mode == 0 || mode == 2)
                {
                    this.posmoves.Clear();
                    pMain = new Playfield();
                    pMain.print = printstuff;
                    this.posmoves.Add(pMain);
                    strt = DateTime.Now;
                    this.doallmoves(false, false);
                    calcTime = (DateTime.Now - strt).TotalSeconds;
                    this.help.logg($"calculated {calcTime}");
                    retval.Add(calcTime);
                }
            }

            if (printstuff)
            {
                this.mainTurnSimulator.printPosmoves();
                this.simmulateWholeTurn();
                this.help.logg($"calculated {calcTime}");
            }

            return retval;
        }

        public void simmulateWholeTurn()
        {
            this.help.ErrorLog("########################################################################################################");
            this.help.ErrorLog("simulate best board");
            this.help.ErrorLog("########################################################################################################");
            //this.bestboard.printActions();

            var tempbestboard = new Playfield();

            tempbestboard.printBoard();

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                this.bestmove.print();

                tempbestboard.doAction(this.bestmove);
            }
            else
            {
                tempbestboard.mana = -100;
            }

            this.help.logg("-------------");
            tempbestboard.printBoard();

            foreach (var bestmovee in this.bestActions)
            {
                this.help.logg("stepp");


                if (bestmovee != null && this.bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
                {
                    bestmovee.print();

                    tempbestboard.doAction(bestmovee);
                }
                else
                {
                    tempbestboard.mana = -100;
                }

                this.help.logg("-------------");
                tempbestboard.printBoard();
            }

            //help.logg("AFTER ENEMY TURN:" );
        }

        public void simmulateWholeTurnandPrint()
        {
            this.help.ErrorLog("###################################");
            this.help.ErrorLog("what would silverfish do?---------");
            this.help.ErrorLog("###################################");
            if (this.bestmoveValue >= 10000)
            {
                this.help.ErrorLog("DETECTED LETHAL ###################################");
            }
            //this.bestboard.printActions();

            var tempbestboard = new Playfield();

            if (this.bestmove != null && this.bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
            {
                tempbestboard.doAction(this.bestmove);
                tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);

                if (this.bestActions.Count == 0)
                {
                    this.help.ErrorLog("end turn");
                }
            }
            else
            {
                tempbestboard.mana = -100;
                this.help.ErrorLog("end turn");
            }


            foreach (var bestmovee in this.bestActions)
            {
                if (bestmovee != null && this.bestmove.actionType != actionEnum.endturn) // save the guessed move, so we doesnt need to recalc!
                {
                    //bestmovee.print();
                    tempbestboard.doAction(bestmovee);
                    tempbestboard.printActionforDummies(tempbestboard.playactions[tempbestboard.playactions.Count - 1]);
                }
                else
                {
                    tempbestboard.mana = -100;
                    this.help.ErrorLog("end turn");
                }
            }
        }

        public void updateEntitiy(int old, int newone)
        {
            Helpfunctions.Instance.logg($"entityupdate! {old} to {newone}");
            if (this.nextMoveGuess != null)
            {
                foreach (var m in this.nextMoveGuess.ownMinions)
                {
                    if (m.entitiyID == old)
                    {
                        m.entitiyID = newone;
                    }
                }

                foreach (var m in this.nextMoveGuess.enemyMinions)
                {
                    if (m.entitiyID == old)
                    {
                        m.entitiyID = newone;
                    }
                }
            }

            foreach (var a in this.bestActions)
            {
                if (a.own != null && a.own.entitiyID == old)
                {
                    a.own.entitiyID = newone;
                }

                if (a.target != null && a.target.entitiyID == old)
                {
                    a.target.entitiyID = newone;
                }

                if (a.card != null && a.card.entity == old)
                {
                    a.card.entity = newone;
                }
            }
        }
    }
}