namespace HREngine.Bots
{
    using Chireiden.Silverfish;
    using HearthDb.Enums;
    using System;
    using System.Collections.Generic;
    using System.IO;


    public class ComboBreaker
    {

        enum combotype
        {
            combo,
            target,
            weaponuse
        }

        private Dictionary<Chireiden.Silverfish.SimCard, int> playByValue = new Dictionary<Chireiden.Silverfish.SimCard, int>();
        private List<combo> combos = new List<combo>();
        public int attackFaceHP = -1;

        Helpfunctions help;

        private static ComboBreaker instance;

        public static ComboBreaker Instance
        {
            get
            {
                return instance ?? (instance = new ComboBreaker());
            }
        }


        public void setInstances()
        {
            help = Helpfunctions.Instance;
            cdb = CardDB.Instance;
        }


        class combo
        {
            private ComboBreaker cb;
            public combotype type = combotype.combo;
            public int neededMana = 0;
            public Dictionary<Chireiden.Silverfish.SimCard, int> combocards = new Dictionary<Chireiden.Silverfish.SimCard, int>();
            public Dictionary<Chireiden.Silverfish.SimCard, int> cardspen = new Dictionary<Chireiden.Silverfish.SimCard, int>();
            public Dictionary<Chireiden.Silverfish.SimCard, int> combocardsTurn0Mobs = new Dictionary<Chireiden.Silverfish.SimCard, int>();
            public Dictionary<Chireiden.Silverfish.SimCard, int> combocardsTurn0All = new Dictionary<Chireiden.Silverfish.SimCard, int>();
            public Dictionary<Chireiden.Silverfish.SimCard, int> combocardsTurn1 = new Dictionary<Chireiden.Silverfish.SimCard, int>();
            public int penality = 0;
            public int combolength = 0;
            public int combot0len = 0;
            public int combot1len = 0;
            public int combot0lenAll = 0;
            public bool twoTurnCombo = false;
            public int bonusForPlaying = 0;
            public int bonusForPlayingT0 = 0;
            public int bonusForPlayingT1 = 0;
            public Chireiden.Silverfish.SimCard requiredWeapon = Chireiden.Silverfish.SimCard.None;
            public CardClass oHero;

            public combo(string s)
            {
                int i = 0;
                this.neededMana = 0;
                requiredWeapon = Chireiden.Silverfish.SimCard.None;
                this.type = combotype.combo;
                this.twoTurnCombo = false;
                bool fixmana = false;
                if (s.Contains("nxttrn")) this.twoTurnCombo = true;
                if (s.Contains("mana:")) fixmana = true;

                /*foreach (string ding in s.Split(':'))
                {
                    if (i == 0)
                    {
                        if (ding == "c") this.type = combotype.combo;
                        if (ding == "t") this.type = combotype.target;
                        if (ding == "w") this.type = combotype.weaponuse;
                    }
                    if (ding == "" || ding == string.Empty) continue;

                    if (i == 1 && type == combotype.combo)
                    {
                        int m = Convert.ToInt32(ding);
                        neededMana = -1;
                        if (m >= 1) neededMana = m;
                    }
                */
                if (type == combotype.combo)
                {
                    this.combolength = 0;
                    this.combot0len = 0;
                    this.combot1len = 0;
                    this.combot0lenAll = 0;
                    int manat0 = 0;
                    int manat1 = -1;
                    bool t1 = false;
                    foreach (string crdl in s.Split(';')) //ding.Split
                    {
                        if (crdl == "" || crdl == string.Empty) continue;
                        if (crdl == "nxttrn")
                        {
                            t1 = true;
                            continue;
                        }
                        if (crdl.StartsWith("mana:"))
                        {
                            this.neededMana = Convert.ToInt32(crdl.Replace("mana:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("hero:"))
                        {
                            this.oHero = Hrtprozis.Instance.heroNametoEnum(crdl.Replace("hero:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonus:"))
                        {
                            this.bonusForPlaying = Convert.ToInt32(crdl.Replace("bonus:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonusfirst:"))
                        {
                            this.bonusForPlayingT0 = Convert.ToInt32(crdl.Replace("bonusfirst:", ""));
                            continue;
                        }
                        if (crdl.StartsWith("bonussecond:"))
                        {
                            this.bonusForPlayingT1 = Convert.ToInt32(crdl.Replace("bonussecond:", ""));
                            continue;
                        }
                        string crd = crdl.Split(',')[0];
                        if (t1)
                        {
                            manat1 += SimCard.FromName(crd).Cost;
                        }
                        else
                        {
                            manat0 += SimCard.FromName(crd).Cost;
                        }
                        this.combolength++;

                        if (combocards.ContainsKey(crd))
                        {
                            combocards[crd]++;
                        }
                        else
                        {
                            combocards.Add(crd, 1);
                            cardspen.Add(crd, Convert.ToInt32(crdl.Split(',')[1]));
                        }

                        if (this.twoTurnCombo)
                        {

                            if (t1)
                            {
                                if (this.combocardsTurn1.ContainsKey(crd))
                                {
                                    combocardsTurn1[crd]++;
                                }
                                else
                                {
                                    combocardsTurn1.Add(crd, 1);
                                }
                                this.combot1len++;
                            }
                            else
                            {
                                Chireiden.Silverfish.SimCard lolcrd = crd;
                                if (lolcrd.Type == CardType.MINION)
                                {
                                    if (this.combocardsTurn0Mobs.ContainsKey(crd))
                                    {
                                        combocardsTurn0Mobs[crd]++;
                                    }
                                    else
                                    {
                                        combocardsTurn0Mobs.Add(crd, 1);
                                    }
                                    this.combot0len++;
                                }
                                if (lolcrd.Type == CardType.WEAPON)
                                {
                                    this.requiredWeapon = lolcrd.CardId;
                                }
                                if (this.combocardsTurn0All.ContainsKey((crd)))
                                {
                                    combocardsTurn0All[(crd)]++;
                                }
                                else
                                {
                                    combocardsTurn0All.Add((crd), 1);
                                }
                                this.combot0lenAll++;
                            }
                        }


                    }
                    if (!fixmana)
                    {
                        this.neededMana = Math.Max(manat1, manat0);
                    }
                }

                /*if (i == 2 && type == combotype.combo)
                {
                    int m = Convert.ToInt32(ding);
                    penality = 0;
                    if (m >= 1) penality = m;
                }

                i++;
            }*/
                this.bonusForPlaying = Math.Max(bonusForPlaying, 1);
                this.bonusForPlayingT0 = Math.Max(bonusForPlayingT0, 1);
                this.bonusForPlayingT1 = Math.Max(bonusForPlayingT1, 1);
            }

            public int isInCombo(List<Handmanager.Handcard> hand, int omm)
            {
                int cardsincombo = 0;
                Dictionary<Chireiden.Silverfish.SimCard, int> combocardscopy = new Dictionary<Chireiden.Silverfish.SimCard, int>(this.combocards);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.card.CardId) && combocardscopy[hc.card.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.card.CardId]--;
                    }
                }
                if (cardsincombo == this.combolength && omm < this.neededMana) return 1;
                if (cardsincombo == this.combolength) return 2;
                if (cardsincombo >= 1) return 1;
                return 0;
            }

            public int isMultiTurnComboTurn1(List<Handmanager.Handcard> hand, int omm, List<Minion> ownmins, Chireiden.Silverfish.SimCard weapon)
            {
                if (!twoTurnCombo) return 0;
                int cardsincombo = 0;
                Dictionary<Chireiden.Silverfish.SimCard, int> combocardscopy = new Dictionary<Chireiden.Silverfish.SimCard, int>(this.combocardsTurn1);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.card.CardId) && combocardscopy[hc.card.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.card.CardId]--;
                    }
                }
                if (cardsincombo == this.combot1len && omm < this.neededMana) return 1;

                if (cardsincombo == this.combot1len)
                {
                    //search for required minions on field
                    int turn0requires = 0;
                    foreach (Chireiden.Silverfish.SimCard s in combocardsTurn0Mobs.Keys)
                    {
                        foreach (Minion m in ownmins)
                        {
                            if (!m.playedThisTurn && m.handcard.card.card.CardId == s)
                            {
                                turn0requires++;
                                break;
                            }
                        }
                    }

                    if (requiredWeapon != Chireiden.Silverfish.SimCard.None && requiredWeapon != weapon) return 1;

                    if (turn0requires >= combot0len) return 2;

                    return 1;
                }
                if (cardsincombo >= 1) return 1;
                return 0;
            }

            public int isMultiTurnComboTurn0(List<Handmanager.Handcard> hand, int omm)
            {
                if (!twoTurnCombo) return 0;
                int cardsincombo = 0;
                Dictionary<Chireiden.Silverfish.SimCard, int> combocardscopy = new Dictionary<Chireiden.Silverfish.SimCard, int>(this.combocardsTurn0All);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.card.CardId) && combocardscopy[hc.card.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.card.CardId]--;
                    }
                }
                if (cardsincombo == this.combot0lenAll && omm < this.neededMana) return 1;

                if (cardsincombo == this.combot0lenAll)
                {
                    return 2;
                }
                if (cardsincombo >= 1) return 1;
                return 0;
            }


            public bool isMultiTurn1Card(Chireiden.Silverfish.SimCard card)
            {
                if (this.combocardsTurn1.ContainsKey(card.card.CardId))
                {
                    return true;
                }
                return false;
            }

            public bool isCardInCombo(Chireiden.Silverfish.SimCard card)
            {
                if (this.combocards.ContainsKey(card.card.CardId))
                {
                    return true;
                }
                return false;
            }

            public int hasPlayedCombo(List<Handmanager.Handcard> hand)
            {
                int cardsincombo = 0;
                Dictionary<Chireiden.Silverfish.SimCard, int> combocardscopy = new Dictionary<Chireiden.Silverfish.SimCard, int>(this.combocards);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.card.CardId) && combocardscopy[hc.card.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combolength) return this.bonusForPlaying;
                return 0;
            }

            public int hasPlayedTurn0Combo(List<Handmanager.Handcard> hand)
            {
                if (this.combocardsTurn0All.Count == 0) return 0;
                int cardsincombo = 0;
                Dictionary<Chireiden.Silverfish.SimCard, int> combocardscopy = new Dictionary<Chireiden.Silverfish.SimCard, int>(this.combocardsTurn0All);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.card.CardId) && combocardscopy[hc.card.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combot0lenAll) return this.bonusForPlayingT0;
                return 0;
            }

            public int hasPlayedTurn1Combo(List<Handmanager.Handcard> hand)
            {
                if (this.combocardsTurn1.Count == 0) return 0;
                int cardsincombo = 0;
                Dictionary<Chireiden.Silverfish.SimCard, int> combocardscopy = new Dictionary<Chireiden.Silverfish.SimCard, int>(this.combocardsTurn1);
                foreach (Handmanager.Handcard hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.card.CardId) && combocardscopy[hc.card.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combot1len) return this.bonusForPlayingT1;
                return 0;
            }

        }

        private ComboBreaker()
        {
            if (attackFaceHP != -1)
            {
                Hrtprozis.Instance.setAttackFaceHP(attackFaceHP);
            }
        }

        public void readCombos(string behavName, bool nameIsPath = false)
        {
            string pathToCombo = behavName;
            if (!nameIsPath)
            {
                if (!Silverfish.Instance.BehaviorPath.ContainsKey(behavName))
                {
                    help.ErrorLog(behavName + ": 没有特定的“连招”.");
                    return;
                }
                pathToCombo = Path.Combine(Silverfish.Instance.BehaviorPath[behavName], "_combo.txt");
            }

            if (!System.IO.File.Exists(pathToCombo))
            {
                help.ErrorLog(behavName + ": 没有特定的“连招”.");
                return;
            }

            help.ErrorLog("[连招功能] 成功加载“连招” " + behavName);
            string[] lines = new string[0] { };
            combos.Clear();
            playByValue.Clear();
            try
            {
                lines = System.IO.File.ReadAllLines(pathToCombo);
            }
            catch
            {
                help.logg("没有发现“连招功能”文本 _combo.txt");
                help.ErrorLog("“连招功能”文本 _combo.txt ");
                return;
            }
            help.logg("加载“连招功能”文本 _combo.txt...");
            help.ErrorLog("加载“连招功能”文本 _combo.txt...");
            foreach (string line in lines)
            {
                if (line == "" || line == null) continue;
                if (line.StartsWith("//")) continue;
                if (line.Contains("weapon:"))
                {
                    try
                    {
                        this.attackFaceHP = Convert.ToInt32(line.Replace("weapon:", ""));
                    }
                    catch
                    {
                        help.logg("[连招功能]不能加载: " + line);
                        help.ErrorLog("[连招功能]不能加载: " + line);
                    }
                }
                else
                {
                    if (line.Contains("cardvalue:"))
                    {
                        try
                        {
                            string cardvalue = line.Replace("cardvalue:", "");
                            Chireiden.Silverfish.SimCard ce = cdb.cardIdstringToEnum(cardvalue.Split(',')[0]);
                            int val = Convert.ToInt32(cardvalue.Split(',')[1]);
                            if (this.playByValue.ContainsKey(ce)) continue;
                            this.playByValue.Add(ce, val);
                            //help.ErrorLog("adding: " + line);
                        }
                        catch
                        {
                            help.logg("[连招功能]不能加载: " + line);
                            help.ErrorLog("[连招功能]不能加载: " + line);
                        }
                    }
                    else
                    {
                        try
                        {
                            combo c = new combo(line);
                            this.combos.Add(c);
                        }
                        catch
                        {
                            help.logg("[连招功能]不能加载: " + line);
                            help.ErrorLog("[连招功能]不能加载: " + line);
                        }
                    }
                }

            }
            help.ErrorLog("[连招功能] " + combos.Count + " “连招”功能激活成功, " + playByValue.Count + " 个权重值已加载");
        }

        public int getPenalityForDestroyingCombo(Chireiden.Silverfish.SimCard crd, Playfield p)
        {
            if (this.combos.Count == 0) return 0;
            int pen = int.MaxValue;
            bool found = false;
            int mana = Math.Max(p.ownMaxMana, p.mana);
            foreach (combo c in this.combos)
            {
                if ((c.oHero == CardClass.INVALID || c.oHero == p.ownHeroName) && c.isCardInCombo(crd))
                {
                    int iia = c.isInCombo(p.owncards, p.ownMaxMana);//check if we have all cards for a combo, and if the choosen card is one
                    int iib = c.isMultiTurnComboTurn1(p.owncards, mana, p.ownMinions, p.ownWeapon.name);

                    int iic = Math.Max(iia, iib);
                    if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd))// it is a card of the combo, is a turn 1 card, but turn 1 is not possible -> we have to play turn 0 cards first
                    {
                        iic = 1;
                    }
                    if (iic == 1) found = true;
                    if (iic == 1 && pen > c.cardspen[crd.card.CardId]) pen = c.cardspen[crd.card.CardId];//iic==1 will destroy combo
                    if (iic == 2) pen = 0;//card is ok to play
                }

            }
            if (found) { return pen; }
            return 0;

        }

        public int checkIfComboWasPlayed(Playfield p)
        {
            if (this.combos.Count == 0) return 0;

            List<Action> alist = p.playactions;
            Chireiden.Silverfish.SimCard weapon = p.ownWeapon.name;
            HeroEnum heroname = p.ownHeroName;

            //returns a penalty only if the combo could be played, but is not played completely
            List<Handmanager.Handcard> playedcards = new List<Handmanager.Handcard>();
            List<combo> searchingCombo = new List<combo>();
            // only check the cards, that are in a combo that can be played:
            int mana = Math.Max(p.ownMaxMana, p.mana);
            foreach (Action a in alist)
            {
                if (a.actionType != actionEnum.playcard) continue;
                Chireiden.Silverfish.SimCard crd = a.card.card;
                foreach (combo c in this.combos)
                {
                    if ((c.oHero == CardClass.INVALID || c.oHero == p.ownHeroName) && c.isCardInCombo(crd))
                    {
                        int iia = c.isInCombo(p.owncards, p.ownMaxMana);
                        int iib = c.isMultiTurnComboTurn1(p.owncards, mana, p.ownMinions, weapon);
                        int iic = Math.Max(iia, iib);
                        if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd))
                        {
                            iic = 1;
                        }
                        if (iic == 2)
                        {
                            playedcards.Add(a.card); // add only the cards, which dont get a penalty
                        }
                    }
                }
            }

            if (playedcards.Count == 0) return 0;
            bool wholeComboPlayed = false;

            int bonus = 0;
            foreach (combo c in this.combos)
            {
                int iia = c.hasPlayedCombo(playedcards);
                int iib = c.hasPlayedTurn0Combo(playedcards);
                int iic = c.hasPlayedTurn1Combo(playedcards);
                int iie = iia + iib + iic;
                if (iie >= 1)
                {
                    wholeComboPlayed = true;
                    bonus -= iie;
                }
            }

            if (wholeComboPlayed) return bonus;
            return 250;

        }

        public int getPlayValue(Chireiden.Silverfish.SimCard ce)
        {
            if (this.playByValue.Count == 0) return 0;
            if (this.playByValue.ContainsKey(ce))
            {
                return -this.playByValue[ce];
            }
            return 0;

        }

    }


}