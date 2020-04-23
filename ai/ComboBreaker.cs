using System;
using System.Collections.Generic;
using System.IO;
using Chireiden.Silverfish;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class ComboBreaker
    {
        enum combotype
        {
            combo,
            target,
            weaponuse
        }

        private Dictionary<SimCard, int> playByValue = new Dictionary<SimCard, int>();
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
            this.help = Helpfunctions.Instance;
        }


        class combo
        {
            private ComboBreaker cb;
            public combotype type = combotype.combo;
            public int neededMana;
            public Dictionary<SimCard, int> combocards = new Dictionary<SimCard, int>();
            public Dictionary<SimCard, int> cardspen = new Dictionary<SimCard, int>();
            public Dictionary<SimCard, int> combocardsTurn0Mobs = new Dictionary<SimCard, int>();
            public Dictionary<SimCard, int> combocardsTurn0All = new Dictionary<SimCard, int>();
            public Dictionary<SimCard, int> combocardsTurn1 = new Dictionary<SimCard, int>();
            public int penality = 0;
            public int combolength;
            public int combot0len;
            public int combot1len;
            public int combot0lenAll;
            public bool twoTurnCombo;
            public int bonusForPlaying;
            public int bonusForPlayingT0;
            public int bonusForPlayingT1;
            public SimCard requiredWeapon = SimCard.None;
            public CardClass oHero;

            public combo(string s)
            {
                var i = 0;
                this.neededMana = 0;
                this.requiredWeapon = SimCard.None;
                this.type = combotype.combo;
                this.twoTurnCombo = false;
                var fixmana = false;
                if (s.Contains("nxttrn"))
                {
                    this.twoTurnCombo = true;
                }

                if (s.Contains("mana:"))
                {
                    fixmana = true;
                }

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
                if (this.type == combotype.combo)
                {
                    this.combolength = 0;
                    this.combot0len = 0;
                    this.combot1len = 0;
                    this.combot0lenAll = 0;
                    var manat0 = 0;
                    var manat1 = -1;
                    var t1 = false;
                    foreach (var crdl in s.Split(';')) //ding.Split
                    {
                        if (crdl == "" || crdl == string.Empty)
                        {
                            continue;
                        }

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
                            this.oHero = SimCard.FromName(crdl.Replace("hero:", "")).CardDef.Class;
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

                        var crd = crdl.Split(',')[0];
                        if (t1)
                        {
                            manat1 += SimCard.FromName(crd).Cost;
                        }
                        else
                        {
                            manat0 += SimCard.FromName(crd).Cost;
                        }

                        this.combolength++;

                        if (this.combocards.ContainsKey(crd))
                        {
                            this.combocards[crd]++;
                        }
                        else
                        {
                            this.combocards.Add(crd, 1);
                            this.cardspen.Add(crd, Convert.ToInt32(crdl.Split(',')[1]));
                        }

                        if (this.twoTurnCombo)
                        {
                            if (t1)
                            {
                                if (this.combocardsTurn1.ContainsKey(crd))
                                {
                                    this.combocardsTurn1[crd]++;
                                }
                                else
                                {
                                    this.combocardsTurn1.Add(crd, 1);
                                }

                                this.combot1len++;
                            }
                            else
                            {
                                SimCard lolcrd = crd;
                                if (lolcrd.Type == CardType.MINION)
                                {
                                    if (this.combocardsTurn0Mobs.ContainsKey(crd))
                                    {
                                        this.combocardsTurn0Mobs[crd]++;
                                    }
                                    else
                                    {
                                        this.combocardsTurn0Mobs.Add(crd, 1);
                                    }

                                    this.combot0len++;
                                }

                                if (lolcrd.Type == CardType.WEAPON)
                                {
                                    this.requiredWeapon = lolcrd.CardId;
                                }

                                if (this.combocardsTurn0All.ContainsKey(crd))
                                {
                                    this.combocardsTurn0All[crd]++;
                                }
                                else
                                {
                                    this.combocardsTurn0All.Add(crd, 1);
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
                this.bonusForPlaying = Math.Max(this.bonusForPlaying, 1);
                this.bonusForPlayingT0 = Math.Max(this.bonusForPlayingT0, 1);
                this.bonusForPlayingT1 = Math.Max(this.bonusForPlayingT1, 1);
            }

            public int isInCombo(List<Handcard> hand, int omm)
            {
                var cardsincombo = 0;
                var combocardscopy = new Dictionary<SimCard, int>(this.combocards);
                foreach (var hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.CardId) && combocardscopy[hc.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combolength && omm < this.neededMana)
                {
                    return 1;
                }

                if (cardsincombo == this.combolength)
                {
                    return 2;
                }

                if (cardsincombo >= 1)
                {
                    return 1;
                }

                return 0;
            }

            public int isMultiTurnComboTurn1(List<Handcard> hand, int omm, List<Minion> ownmins, SimCard weapon)
            {
                if (!this.twoTurnCombo)
                {
                    return 0;
                }

                var cardsincombo = 0;
                var combocardscopy = new Dictionary<SimCard, int>(this.combocardsTurn1);
                foreach (var hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.CardId) && combocardscopy[hc.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combot1len && omm < this.neededMana)
                {
                    return 1;
                }

                if (cardsincombo == this.combot1len)
                {
                    //search for required minions on field
                    var turn0requires = 0;
                    foreach (var s in this.combocardsTurn0Mobs.Keys)
                    {
                        foreach (var m in ownmins)
                        {
                            if (!m.playedThisTurn && m.handcard.card.CardId == s)
                            {
                                turn0requires++;
                                break;
                            }
                        }
                    }

                    if (this.requiredWeapon != SimCard.None && this.requiredWeapon != weapon)
                    {
                        return 1;
                    }

                    if (turn0requires >= this.combot0len)
                    {
                        return 2;
                    }

                    return 1;
                }

                if (cardsincombo >= 1)
                {
                    return 1;
                }

                return 0;
            }

            public int isMultiTurnComboTurn0(List<Handcard> hand, int omm)
            {
                if (!this.twoTurnCombo)
                {
                    return 0;
                }

                var cardsincombo = 0;
                var combocardscopy = new Dictionary<SimCard, int>(this.combocardsTurn0All);
                foreach (var hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.CardId) && combocardscopy[hc.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combot0lenAll && omm < this.neededMana)
                {
                    return 1;
                }

                if (cardsincombo == this.combot0lenAll)
                {
                    return 2;
                }

                if (cardsincombo >= 1)
                {
                    return 1;
                }

                return 0;
            }


            public bool isMultiTurn1Card(SimCard card)
            {
                if (this.combocardsTurn1.ContainsKey(card.CardId))
                {
                    return true;
                }

                return false;
            }

            public bool isCardInCombo(SimCard card)
            {
                if (this.combocards.ContainsKey(card.CardId))
                {
                    return true;
                }

                return false;
            }

            public int hasPlayedCombo(List<Handcard> hand)
            {
                var cardsincombo = 0;
                var combocardscopy = new Dictionary<SimCard, int>(this.combocards);
                foreach (var hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.CardId) && combocardscopy[hc.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combolength)
                {
                    return this.bonusForPlaying;
                }

                return 0;
            }

            public int hasPlayedTurn0Combo(List<Handcard> hand)
            {
                if (this.combocardsTurn0All.Count == 0)
                {
                    return 0;
                }

                var cardsincombo = 0;
                var combocardscopy = new Dictionary<SimCard, int>(this.combocardsTurn0All);
                foreach (var hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.CardId) && combocardscopy[hc.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combot0lenAll)
                {
                    return this.bonusForPlayingT0;
                }

                return 0;
            }

            public int hasPlayedTurn1Combo(List<Handcard> hand)
            {
                if (this.combocardsTurn1.Count == 0)
                {
                    return 0;
                }

                var cardsincombo = 0;
                var combocardscopy = new Dictionary<SimCard, int>(this.combocardsTurn1);
                foreach (var hc in hand)
                {
                    if (combocardscopy.ContainsKey(hc.card.CardId) && combocardscopy[hc.card.CardId] >= 1)
                    {
                        cardsincombo++;
                        combocardscopy[hc.card.CardId]--;
                    }
                }

                if (cardsincombo == this.combot1len)
                {
                    return this.bonusForPlayingT1;
                }

                return 0;
            }
        }

        private ComboBreaker()
        {
            if (this.attackFaceHP != -1)
            {
                Hrtprozis.Instance.setAttackFaceHP(this.attackFaceHP);
            }
        }

        public void readCombos(string behavName, bool nameIsPath = false)
        {
            var pathToCombo = behavName;
            if (!nameIsPath)
            {
                if (!Silverfish.Instance.BehaviorPath.ContainsKey(behavName))
                {
                    this.help.ErrorLog($"{behavName}: 没有特定的“连招”.");
                    return;
                }

                pathToCombo = Path.Combine(Silverfish.Instance.BehaviorPath[behavName], "_combo.txt");
            }

            if (!File.Exists(pathToCombo))
            {
                this.help.ErrorLog($"{behavName}: 没有特定的“连招”.");
                return;
            }

            this.help.ErrorLog($"[连招功能] 成功加载“连招” {behavName}");
            var lines = new string[0] { };
            this.combos.Clear();
            this.playByValue.Clear();
            try
            {
                lines = File.ReadAllLines(pathToCombo);
            }
            catch
            {
                this.help.logg("没有发现“连招功能”文本 _combo.txt");
                this.help.ErrorLog("“连招功能”文本 _combo.txt ");
                return;
            }

            this.help.logg("加载“连招功能”文本 _combo.txt...");
            this.help.ErrorLog("加载“连招功能”文本 _combo.txt...");
            foreach (var line in lines)
            {
                if (line == "" || line == null)
                {
                    continue;
                }

                if (line.StartsWith("//"))
                {
                    continue;
                }

                if (line.Contains("weapon:"))
                {
                    try
                    {
                        this.attackFaceHP = Convert.ToInt32(line.Replace("weapon:", ""));
                    }
                    catch
                    {
                        this.help.logg($"[连招功能]不能加载: {line}");
                        this.help.ErrorLog($"[连招功能]不能加载: {line}");
                    }
                }
                else
                {
                    if (line.Contains("cardvalue:"))
                    {
                        try
                        {
                            var cardvalue = line.Replace("cardvalue:", "");
                            SimCard ce = cardvalue.Split(',')[0];
                            var val = Convert.ToInt32(cardvalue.Split(',')[1]);
                            if (this.playByValue.ContainsKey(ce))
                            {
                                continue;
                            }

                            this.playByValue.Add(ce, val);
                            //help.ErrorLog("adding: " + line);
                        }
                        catch
                        {
                            this.help.logg($"[连招功能]不能加载: {line}");
                            this.help.ErrorLog($"[连招功能]不能加载: {line}");
                        }
                    }
                    else
                    {
                        try
                        {
                            var c = new combo(line);
                            this.combos.Add(c);
                        }
                        catch
                        {
                            this.help.logg($"[连招功能]不能加载: {line}");
                            this.help.ErrorLog($"[连招功能]不能加载: {line}");
                        }
                    }
                }
            }

            this.help.ErrorLog($"[连招功能] {this.combos.Count} “连招”功能激活成功, {this.playByValue.Count} 个权重值已加载");
        }

        public int getPenalityForDestroyingCombo(SimCard crd, Playfield p)
        {
            if (this.combos.Count == 0)
            {
                return 0;
            }

            var pen = int.MaxValue;
            var found = false;
            var mana = Math.Max(p.ownMaxMana, p.mana);
            foreach (var c in this.combos)
            {
                if ((c.oHero == CardClass.INVALID || c.oHero == p.ownHero.CardClass) && c.isCardInCombo(crd))
                {
                    var iia = c.isInCombo(p.owncards, p.ownMaxMana); //check if we have all cards for a combo, and if the choosen card is one
                    var iib = c.isMultiTurnComboTurn1(p.owncards, mana, p.ownMinions, p.ownWeapon.name);

                    var iic = Math.Max(iia, iib);
                    if (iia == 2 && iib != 2 && c.isMultiTurn1Card(crd)) // it is a card of the combo, is a turn 1 card, but turn 1 is not possible -> we have to play turn 0 cards first
                    {
                        iic = 1;
                    }

                    if (iic == 1)
                    {
                        found = true;
                    }

                    if (iic == 1 && pen > c.cardspen[crd.CardId])
                    {
                        pen = c.cardspen[crd.CardId]; //iic==1 will destroy combo
                    }

                    if (iic == 2)
                    {
                        pen = 0; //card is ok to play
                    }
                }
            }

            if (found) { return pen; }

            return 0;
        }

        public int checkIfComboWasPlayed(Playfield p)
        {
            if (this.combos.Count == 0)
            {
                return 0;
            }

            var alist = p.playactions;
            var weapon = p.ownWeapon.name;
            var heroname = p.ownHero.CardClass;

            //returns a penalty only if the combo could be played, but is not played completely
            var playedcards = new List<Handcard>();
            var searchingCombo = new List<combo>();
            // only check the cards, that are in a combo that can be played:
            var mana = Math.Max(p.ownMaxMana, p.mana);
            foreach (var a in alist)
            {
                if (a.actionType != actionEnum.playcard)
                {
                    continue;
                }

                var crd = a.card.card;
                foreach (var c in this.combos)
                {
                    if ((c.oHero == CardClass.INVALID || c.oHero == p.ownHero.CardClass) && c.isCardInCombo(crd))
                    {
                        var iia = c.isInCombo(p.owncards, p.ownMaxMana);
                        var iib = c.isMultiTurnComboTurn1(p.owncards, mana, p.ownMinions, weapon);
                        var iic = Math.Max(iia, iib);
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

            if (playedcards.Count == 0)
            {
                return 0;
            }

            var wholeComboPlayed = false;

            var bonus = 0;
            foreach (var c in this.combos)
            {
                var iia = c.hasPlayedCombo(playedcards);
                var iib = c.hasPlayedTurn0Combo(playedcards);
                var iic = c.hasPlayedTurn1Combo(playedcards);
                var iie = iia + iib + iic;
                if (iie >= 1)
                {
                    wholeComboPlayed = true;
                    bonus -= iie;
                }
            }

            if (wholeComboPlayed)
            {
                return bonus;
            }

            return 250;
        }

        public int getPlayValue(SimCard ce)
        {
            if (this.playByValue.Count == 0)
            {
                return 0;
            }

            if (this.playByValue.ContainsKey(ce))
            {
                return -this.playByValue[ce];
            }

            return 0;
        }
    }
}