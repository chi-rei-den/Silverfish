using System;
using System.Collections.Generic;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public struct GraveYardItem
    {
        public bool own;
        public int entity;
        public SimCard cardid;

        public GraveYardItem(SimCard id, int entity, bool own)
        {
            this.own = own;
            this.cardid = id;
            this.entity = entity;
        }
    }

    public class SecretItem
    {
        public bool triggered;

        /*not in use temporarily 1
        public bool canbeTriggeredWithAttackingHero = true;
        public bool canbeTriggeredWithAttackingMinion = true;
        public bool canbeTriggeredWithPlayingMinion = true;
        public bool canbeTriggeredWithPlayingHeroPower = true;*/

        public bool canBe_snaketrap = true;
        public bool canBe_snipe = true;
        public bool canBe_explosive = true;
        public bool canBe_beartrap = true;
        public bool canBe_freezing = true;
        public bool canBe_missdirection = true;
        public bool canBe_darttrap = true;
        public bool canBe_cattrick = true;

        public bool canBe_counterspell = true;
        public bool canBe_icebarrier = true;
        public bool canBe_iceblock = true;
        public bool canBe_mirrorentity = true;
        public bool canBe_spellbender = true;
        public bool canBe_vaporize = true;
        public bool canBe_duplicate = true;
        public bool canBe_effigy = true;

        public bool canBe_eyeforaneye = true;
        public bool canBe_noblesacrifice = true;
        public bool canBe_redemption = true;
        public bool canBe_repentance = true;
        public bool canBe_avenge = true;
        public bool canBe_sacredtrial = true;

        public int entityId;

        public SecretItem()
        {
        }

        public SecretItem(SecretItem sec)
        {
            this.triggered = sec.triggered;
            /*not in use temporarily 1
            this.canbeTriggeredWithAttackingHero = sec.canbeTriggeredWithAttackingHero;
            this.canbeTriggeredWithAttackingMinion = sec.canbeTriggeredWithAttackingMinion;
            this.canbeTriggeredWithPlayingMinion = sec.canbeTriggeredWithPlayingMinion;
            this.canbeTriggeredWithPlayingHeroPower = sec.canbeTriggeredWithPlayingHeroPower;*/

            this.canBe_avenge = sec.canBe_avenge;
            this.canBe_counterspell = sec.canBe_counterspell;
            this.canBe_duplicate = sec.canBe_duplicate;
            this.canBe_effigy = sec.canBe_effigy;
            this.canBe_explosive = sec.canBe_explosive;
            this.canBe_beartrap = sec.canBe_beartrap;
            this.canBe_eyeforaneye = sec.canBe_eyeforaneye;
            this.canBe_freezing = sec.canBe_freezing;
            this.canBe_icebarrier = sec.canBe_icebarrier;
            this.canBe_iceblock = sec.canBe_iceblock;
            this.canBe_cattrick = sec.canBe_cattrick;
            this.canBe_mirrorentity = sec.canBe_mirrorentity;
            this.canBe_missdirection = sec.canBe_missdirection;
            this.canBe_darttrap = sec.canBe_darttrap;
            this.canBe_noblesacrifice = sec.canBe_noblesacrifice;
            this.canBe_redemption = sec.canBe_redemption;
            this.canBe_repentance = sec.canBe_repentance;
            this.canBe_snaketrap = sec.canBe_snaketrap;
            this.canBe_snipe = sec.canBe_snipe;
            this.canBe_spellbender = sec.canBe_spellbender;
            this.canBe_vaporize = sec.canBe_vaporize;
            this.canBe_sacredtrial = sec.canBe_sacredtrial;

            this.entityId = sec.entityId;
        }

        public SecretItem(string secdata)
        {
            this.entityId = Convert.ToInt32(secdata.Split('.')[0]);

            var canbe = secdata.Split('.')[1];
            if (canbe.Length < 17)
            {
                Helpfunctions.Instance.ErrorLog($"cant read secret {secdata} {canbe.Length}");
            }

            this.canBe_snaketrap = false;
            this.canBe_snipe = false;
            this.canBe_explosive = false;
            this.canBe_beartrap = false;
            this.canBe_freezing = false;
            this.canBe_missdirection = false;
            this.canBe_darttrap = false;
            this.canBe_cattrick = false;

            this.canBe_counterspell = false;
            this.canBe_icebarrier = false;
            this.canBe_iceblock = false;
            this.canBe_mirrorentity = false;
            this.canBe_spellbender = false;
            this.canBe_vaporize = false;
            this.canBe_duplicate = false;
            this.canBe_effigy = false;

            this.canBe_eyeforaneye = false;
            this.canBe_noblesacrifice = false;
            this.canBe_redemption = false;
            this.canBe_repentance = false;
            this.canBe_avenge = false;
            this.canBe_sacredtrial = false;

            if (canbe.Length == 22) //new
            {
                this.canBe_snaketrap = canbe[0] == '1';
                this.canBe_snipe = canbe[1] == '1';
                this.canBe_explosive = canbe[2] == '1';
                this.canBe_beartrap = canbe[3] == '1';
                this.canBe_freezing = canbe[4] == '1';
                this.canBe_missdirection = canbe[5] == '1';
                this.canBe_darttrap = canbe[6] == '1';
                this.canBe_cattrick = canbe[7] == '1';

                this.canBe_counterspell = canbe[8] == '1';
                this.canBe_icebarrier = canbe[9] == '1';
                this.canBe_iceblock = canbe[10] == '1';
                this.canBe_mirrorentity = canbe[11] == '1';
                this.canBe_spellbender = canbe[12] == '1';
                this.canBe_vaporize = canbe[13] == '1';
                this.canBe_duplicate = canbe[14] == '1';
                this.canBe_effigy = canbe[15] == '1';

                this.canBe_eyeforaneye = canbe[16] == '1';
                this.canBe_noblesacrifice = canbe[17] == '1';
                this.canBe_redemption = canbe[18] == '1';
                this.canBe_repentance = canbe[19] == '1';
                this.canBe_avenge = canbe[20] == '1';
                this.canBe_sacredtrial = canbe[21] == '1';
            }
            else if (canbe.Length == 21)
            {
                this.canBe_snaketrap = canbe[0] == '1';
                this.canBe_snipe = canbe[1] == '1';
                this.canBe_explosive = canbe[2] == '1';
                this.canBe_beartrap = canbe[3] == '1';
                this.canBe_freezing = canbe[4] == '1';
                this.canBe_missdirection = canbe[5] == '1';
                this.canBe_darttrap = canbe[6] == '1';

                this.canBe_counterspell = canbe[7] == '1';
                this.canBe_icebarrier = canbe[8] == '1';
                this.canBe_iceblock = canbe[9] == '1';
                this.canBe_mirrorentity = canbe[10] == '1';
                this.canBe_spellbender = canbe[11] == '1';
                this.canBe_vaporize = canbe[12] == '1';
                this.canBe_duplicate = canbe[13] == '1';
                this.canBe_effigy = canbe[14] == '1';

                this.canBe_eyeforaneye = canbe[15] == '1';
                this.canBe_noblesacrifice = canbe[16] == '1';
                this.canBe_redemption = canbe[17] == '1';
                this.canBe_repentance = canbe[18] == '1';
                this.canBe_avenge = canbe[19] == '1';
                this.canBe_sacredtrial = canbe[20] == '1';
            }
            else if (canbe.Length == 20) //old
            {
                this.canBe_snaketrap = canbe[0] == '1';
                this.canBe_snipe = canbe[1] == '1';
                this.canBe_explosive = canbe[2] == '1';
                this.canBe_beartrap = canbe[3] == '1';
                this.canBe_freezing = canbe[4] == '1';
                this.canBe_missdirection = canbe[5] == '1';
                this.canBe_darttrap = canbe[6] == '1';

                this.canBe_counterspell = canbe[7] == '1';
                this.canBe_icebarrier = canbe[8] == '1';
                this.canBe_iceblock = canbe[9] == '1';
                this.canBe_mirrorentity = canbe[10] == '1';
                this.canBe_spellbender = canbe[11] == '1';
                this.canBe_vaporize = canbe[12] == '1';
                this.canBe_duplicate = canbe[13] == '1';

                this.canBe_eyeforaneye = canbe[14] == '1';
                this.canBe_noblesacrifice = canbe[15] == '1';
                this.canBe_redemption = canbe[16] == '1';
                this.canBe_repentance = canbe[17] == '1';
                this.canBe_avenge = canbe[18] == '1';
                this.canBe_sacredtrial = canbe[19] == '1';
            }

            this.updateCanBeTriggered();
        }

        public void updateCanBeTriggered()
        {
            /*not in use temporarily 1
            this.canbeTriggeredWithAttackingHero = false;
            this.canbeTriggeredWithAttackingMinion = false;
            this.canbeTriggeredWithPlayingMinion = false;
            this.canbeTriggeredWithPlayingHeroPower = false;

            if (this.canBe_snipe || this.canBe_mirrorentity || this.canBe_repentance || this.canBe_sacredtrial) this.canbeTriggeredWithPlayingMinion = true;

            if (this.canBe_explosive || this.canBe_beartrap || this.canBe_missdirection || this.canBe_freezing || this.canBe_icebarrier || this.canBe_vaporize || this.canBe_noblesacrifice) this.canbeTriggeredWithAttackingHero = true;

            if (this.canBe_snaketrap || this.canBe_freezing || this.canBe_noblesacrifice) this.canbeTriggeredWithAttackingMinion = true;

            if (this.canBe_darttrap) this.canbeTriggeredWithPlayingHeroPower = true;
            */
        }

        public void usedTrigger_CharIsAttacked(bool DefenderIsHero, bool AttackerIsHero)
        {
            if (DefenderIsHero)
            {
                this.canBe_explosive = false;
                this.canBe_beartrap = false;
                this.canBe_missdirection = false;

                this.canBe_icebarrier = false;
                this.canBe_vaporize = false;
            }
            else
            {
                this.canBe_snaketrap = false;
            }

            if (!AttackerIsHero)
            {
                this.canBe_freezing = false;
            }

            this.canBe_noblesacrifice = false;
            this.updateCanBeTriggered();
        }

        public void usedTrigger_MinionIsPlayed(int i)
        {
            this.canBe_snipe = false;
            this.canBe_mirrorentity = false;
            this.canBe_repentance = false;
            if (i == 1)
            {
                this.canBe_sacredtrial = false;
            }

            this.updateCanBeTriggered();
        }

        public void usedTrigger_SpellIsPlayed(bool minionIsTarget)
        {
            this.canBe_counterspell = false;
            this.canBe_cattrick = false;
            if (minionIsTarget)
            {
                this.canBe_spellbender = false;
            }

            this.updateCanBeTriggered();
        }

        public void usedTrigger_MinionDied()
        {
            this.canBe_avenge = false;
            this.canBe_redemption = false;
            this.canBe_duplicate = false;
            this.canBe_effigy = false;
            this.updateCanBeTriggered();
        }

        public void usedTrigger_HeroGotDmg(bool deadly = false)
        {
            this.canBe_eyeforaneye = false;
            if (deadly)
            {
                this.canBe_iceblock = false;
            }

            this.updateCanBeTriggered();
        }

        public void usedTrigger_HeroPowerUsed()
        {
            this.canBe_darttrap = false;
            this.updateCanBeTriggered();
        }


        public string returnAString()
        {
            var retval = $"{this.entityId}.";
            retval += $"{(this.canBe_snaketrap ? "1" : "0")}";
            retval += $"{(this.canBe_snipe ? "1" : "0")}";
            retval += $"{(this.canBe_explosive ? "1" : "0")}";
            retval += $"{(this.canBe_beartrap ? "1" : "0")}";
            retval += $"{(this.canBe_freezing ? "1" : "0")}";
            retval += $"{(this.canBe_missdirection ? "1" : "0")}";
            retval += $"{(this.canBe_darttrap ? "1" : "0")}";
            retval += $"{(this.canBe_cattrick ? "1" : "0")}";

            retval += $"{(this.canBe_counterspell ? "1" : "0")}";
            retval += $"{(this.canBe_icebarrier ? "1" : "0")}";
            retval += $"{(this.canBe_iceblock ? "1" : "0")}";
            retval += $"{(this.canBe_mirrorentity ? "1" : "0")}";
            retval += $"{(this.canBe_spellbender ? "1" : "0")}";
            retval += $"{(this.canBe_vaporize ? "1" : "0")}";
            retval += $"{(this.canBe_duplicate ? "1" : "0")}";
            retval += $"{(this.canBe_effigy ? "1" : "0")}";

            retval += $"{(this.canBe_eyeforaneye ? "1" : "0")}";
            retval += $"{(this.canBe_noblesacrifice ? "1" : "0")}";
            retval += $"{(this.canBe_redemption ? "1" : "0")}";
            retval += $"{(this.canBe_repentance ? "1" : "0")}";
            retval += $"{(this.canBe_avenge ? "1" : "0")}";
            retval += $"{(this.canBe_sacredtrial ? "1" : "0")}";
            return $"{retval},";
        }

        public bool isEqual(SecretItem s)
        {
            var result = this.entityId == s.entityId;
            if (!result)
            {
                result = result && this.canBe_avenge == s.canBe_avenge && this.canBe_counterspell == s.canBe_counterspell && this.canBe_duplicate == s.canBe_duplicate && this.canBe_effigy == s.canBe_effigy && this.canBe_explosive == s.canBe_explosive;
                result = result && this.canBe_eyeforaneye == s.canBe_eyeforaneye && this.canBe_freezing == s.canBe_freezing && this.canBe_icebarrier == s.canBe_icebarrier && this.canBe_iceblock == s.canBe_iceblock;
                result = result && this.canBe_mirrorentity == s.canBe_mirrorentity && this.canBe_missdirection == s.canBe_missdirection && this.canBe_noblesacrifice == s.canBe_noblesacrifice && this.canBe_redemption == s.canBe_redemption;
                result = result && this.canBe_repentance == s.canBe_repentance && this.canBe_snaketrap == s.canBe_snaketrap && this.canBe_snipe == s.canBe_snipe && this.canBe_spellbender == s.canBe_spellbender && this.canBe_vaporize == s.canBe_vaporize;
                result = result && this.canBe_sacredtrial == s.canBe_sacredtrial && this.canBe_darttrap == s.canBe_darttrap && this.canBe_beartrap == s.canBe_beartrap && this.canBe_cattrick == s.canBe_cattrick;
            }

            return result;
        }
    }

    public class Probabilitymaker
    {
        public Dictionary<SimCard, int> ownCardsOut = new Dictionary<SimCard, int>();
        public Dictionary<SimCard, int> enemyCardsOut = new Dictionary<SimCard, int>();
        List<GraveYardItem> graveyard = new List<GraveYardItem>();
        public List<GraveYardItem> turngraveyard = new List<GraveYardItem>(); //MOBS only
        public List<GraveYardItem> turngraveyardAll = new List<GraveYardItem>(); //All
        List<GraveYardItem> graveyartTillTurnStart = new List<GraveYardItem>();

        public List<SecretItem> enemySecrets = new List<SecretItem>();

        public bool feugenDead;
        public bool stalaggDead;

        private static Probabilitymaker instance;

        public static Probabilitymaker Instance
        {
            get
            {
                return instance ?? (instance = new Probabilitymaker());
            }
        }

        private Probabilitymaker()
        {
        }

        public void setOwnCardsOut(Dictionary<SimCard, int> og)
        {
            this.ownCardsOut.Clear();
            this.stalaggDead = false;
            this.feugenDead = false;
            foreach (var tmp in og)
            {
                this.ownCardsOut.Add(tmp.Key, tmp.Value);
                if (tmp.Key == CardIds.Collectible.Neutral.Feugen)
                {
                    this.feugenDead = true;
                }

                if (tmp.Key == CardIds.Collectible.Neutral.Stalagg)
                {
                    this.stalaggDead = true;
                }
            }
        }

        public void setEnemyCardsOut(Dictionary<SimCard, int> eg)
        {
            this.enemyCardsOut.Clear();
            foreach (var tmp in eg)
            {
                this.enemyCardsOut.Add(tmp.Key, tmp.Value);
                if (tmp.Key == CardIds.Collectible.Neutral.Feugen)
                {
                    this.feugenDead = true;
                }

                if (tmp.Key == CardIds.Collectible.Neutral.Stalagg)
                {
                    this.stalaggDead = true;
                }
            }
        }

        public void printTurnGraveYard()
        {
            /*string g = "";
            if (Probabilitymaker.Instance.feugenDead) g += " fgn";
            if (Probabilitymaker.Instance.stalaggDead) g += " stlgg";
            Helpfunctions.Instance.logg("GraveYard:" + g);
            if (writetobuffer) Helpfunctions.Instance.writeToBuffer("GraveYard:" + g);*/

            var s = "ownDiedMinions: ";
            foreach (var gyi in this.turngraveyard)
            {
                if (gyi.own)
                {
                    s += $"{gyi.cardid},{gyi.entity};";
                }
            }

            Helpfunctions.Instance.logg(s);

            s = "enemyDiedMinions: ";
            foreach (var gyi in this.turngraveyard)
            {
                if (!gyi.own)
                {
                    s += $"{gyi.cardid},{gyi.entity};";
                }
            }

            Helpfunctions.Instance.logg(s);


            s = "otg: ";
            foreach (var gyi in this.turngraveyardAll)
            {
                if (gyi.own)
                {
                    s += $"{gyi.cardid},{gyi.entity};";
                }
            }

            Helpfunctions.Instance.logg(s);

            s = "etg: ";
            foreach (var gyi in this.turngraveyardAll)
            {
                if (!gyi.own)
                {
                    s += $"{gyi.cardid},{gyi.entity};";
                }
            }

            Helpfunctions.Instance.logg(s);
        }

        public void setGraveYard(List<GraveYardItem> list, bool turnStart)
        {
            this.graveyard.Clear();
            this.graveyard.AddRange(list);
            if (turnStart)
            {
                this.graveyartTillTurnStart.Clear();
                this.graveyartTillTurnStart.AddRange(list);
            }

            this.stalaggDead = false;
            this.feugenDead = false;
            this.turngraveyard.Clear();
            this.turngraveyardAll.Clear();

            var OwnLastDiedMinion = new GraveYardItem(SimCard.None, -1, true);
            foreach (var ent in list)
            {
                if (ent.cardid == CardIds.Collectible.Neutral.Feugen)
                {
                    this.feugenDead = true;
                }

                if (ent.cardid == CardIds.Collectible.Neutral.Stalagg)
                {
                    this.stalaggDead = true;
                }

                var found = false;

                foreach (var gyi in this.graveyartTillTurnStart)
                {
                    if (ent.entity == gyi.entity)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (ent.cardid.Type == CardType.MINION)
                    {
                        this.turngraveyard.Add(ent);
                    }

                    this.turngraveyardAll.Add(ent);
                }

                if (ent.own && ent.cardid.Type == CardType.MINION)
                {
                    OwnLastDiedMinion = ent;
                }
            }

            Hrtprozis.Instance.updateOwnLastDiedMinion(OwnLastDiedMinion.cardid);
        }

        public void setTurnGraveYard(List<GraveYardItem> listMobs, List<GraveYardItem> listAll)
        {
            this.turngraveyard.Clear();
            this.turngraveyardAll.Clear();
            this.turngraveyard.AddRange(listMobs);
            this.turngraveyardAll.AddRange(listAll);
        }

        public bool hasEnemyThisCardInDeck(SimCard cardid)
        {
            if (this.enemyCardsOut.ContainsKey(cardid))
            {
                if (this.enemyCardsOut[cardid] == 1)
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        public int anzCardsInDeck(SimCard cardid)
        {
            var ret = 2;
            var c = cardid;
            if (c.Rarity == Rarity.LEGENDARY)
            {
                ret = 1; //you can have only one rare;
            }

            if (this.enemyCardsOut.ContainsKey(cardid))
            {
                if (this.enemyCardsOut[cardid] == 1)
                {
                    return 1;
                }

                return 0;
            }

            return ret;
        }

        public void printGraveyards()
        {
            var og = "og: ";
            foreach (var e in this.ownCardsOut)
            {
                og += $"{e.Key},{e.Value};";
            }

            var eg = "eg: ";
            foreach (var e in this.enemyCardsOut)
            {
                eg += $"{e.Key},{e.Value};";
            }

            Helpfunctions.Instance.logg(og);
            Helpfunctions.Instance.logg(eg);
        }

        public int getProbOfEnemyHavingCardInHand(SimCard cardid, int handsize, int decksize)
        {
            //calculates probability \in [0,...,100]


            var cardsremaining = this.anzCardsInDeck(cardid);
            if (cardsremaining == 0)
            {
                return 0;
            }

            var retval = 0.0;
            //http://de.wikipedia.org/wiki/Hypergeometrische_Verteilung (we calculte 1-p(x=0))

            if (cardsremaining == 1)
            {
                retval = 1.0 - decksize / (double)(decksize + handsize);
            }
            else
            {
                retval = 1.0 - decksize * (decksize - 1) / (double)((decksize + handsize) * (decksize + handsize - 1));
            }

            retval = Math.Min(retval, 1.0);

            return (int)(100.0 * retval);
        }

        public bool hasCardinGraveyard(SimCard cardid)
        {
            foreach (var gyi in this.graveyard)
            {
                if (gyi.cardid == cardid)
                {
                    return true;
                }
            }

            return false;
        }

        public void setEnemySecretGuesses(Dictionary<int, CardClass> enemySecretList)
        {
            var newlist = new List<SecretItem>();

            foreach (var eSec in enemySecretList)
            {
                if (eSec.Key >= 1000)
                {
                    continue;
                }

                Helpfunctions.Instance.logg($"detect secret with id{eSec.Key}");
                var sec = this.getNewSecretGuessedItem(eSec.Key, eSec.Value);

                newlist.Add(new SecretItem(sec));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(newlist);
        }

        public SecretItem getNewSecretGuessedItem(int entityid, CardClass SecClass)
        {
            foreach (var si in this.enemySecrets)
            {
                if (si.entityId == entityid && entityid < 1000)
                {
                    return si;
                }
            }

            switch (SecClass)
            {
                case CardClass.WARRIOR:
                case CardClass.WARLOCK:
                case CardClass.ROGUE:
                case CardClass.SHAMAN:
                case CardClass.PRIEST:
                case CardClass.PALADIN:
                case CardClass.MAGE:
                case CardClass.HUNTER:
                case CardClass.DRUID:
                case CardClass.DEMONHUNTER:
                    break;
                default:
                    Helpfunctions.Instance.ErrorLog($"Problem is detected: undefined Secret class {SecClass}");
                    SecClass = Hrtprozis.Instance.enemyHero.CardClass;
                    Helpfunctions.Instance.ErrorLog($"attempt to restore... {SecClass}");
                    break;
            }


            var sec = new SecretItem {entityId = entityid};
            if (SecClass == CardClass.HUNTER)
            {
                sec.canBe_counterspell = false;
                sec.canBe_icebarrier = false;
                sec.canBe_iceblock = false;
                sec.canBe_mirrorentity = false;
                sec.canBe_spellbender = false;
                sec.canBe_vaporize = false;
                sec.canBe_duplicate = false;
                sec.canBe_effigy = false;

                sec.canBe_eyeforaneye = false;
                sec.canBe_noblesacrifice = false;
                sec.canBe_redemption = false;
                sec.canBe_repentance = false;
                sec.canBe_avenge = false;
                sec.canBe_sacredtrial = false;

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.SnakeTrap) && this.enemyCardsOut[CardIds.Collectible.Hunter.SnakeTrap] >= 2)
                {
                    sec.canBe_snaketrap = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.Snipe) && this.enemyCardsOut[CardIds.Collectible.Hunter.Snipe] >= 2)
                {
                    sec.canBe_snipe = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.ExplosiveTrap) && this.enemyCardsOut[CardIds.Collectible.Hunter.ExplosiveTrap] >= 2)
                {
                    sec.canBe_explosive = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.BearTrap) && this.enemyCardsOut[CardIds.Collectible.Hunter.BearTrap] >= 2)
                {
                    sec.canBe_beartrap = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.FreezingTrap) && this.enemyCardsOut[CardIds.Collectible.Hunter.FreezingTrap] >= 2)
                {
                    sec.canBe_freezing = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.Misdirection) && this.enemyCardsOut[CardIds.Collectible.Hunter.Misdirection] >= 2)
                {
                    sec.canBe_missdirection = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.DartTrap) && this.enemyCardsOut[CardIds.Collectible.Hunter.DartTrap] >= 2)
                {
                    sec.canBe_darttrap = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Hunter.CatTrick) && this.enemyCardsOut[CardIds.Collectible.Hunter.CatTrick] >= 2)
                {
                    sec.canBe_cattrick = false;
                }
            }

            if (SecClass == CardClass.MAGE)
            {
                sec.canBe_snaketrap = false;
                sec.canBe_snipe = false;
                sec.canBe_explosive = false;
                sec.canBe_beartrap = false;
                sec.canBe_freezing = false;
                sec.canBe_missdirection = false;
                sec.canBe_darttrap = false;
                sec.canBe_cattrick = false;

                sec.canBe_eyeforaneye = false;
                sec.canBe_noblesacrifice = false;
                sec.canBe_redemption = false;
                sec.canBe_repentance = false;
                sec.canBe_avenge = false;
                sec.canBe_sacredtrial = false;

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.Counterspell) && this.enemyCardsOut[CardIds.Collectible.Mage.Counterspell] >= 2)
                {
                    sec.canBe_counterspell = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.IceBarrier) && this.enemyCardsOut[CardIds.Collectible.Mage.IceBarrier] >= 2)
                {
                    sec.canBe_icebarrier = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.IceBlock) && this.enemyCardsOut[CardIds.Collectible.Mage.IceBlock] >= 2)
                {
                    sec.canBe_iceblock = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.MirrorEntity) && this.enemyCardsOut[CardIds.Collectible.Mage.MirrorEntity] >= 2)
                {
                    sec.canBe_mirrorentity = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.Spellbender) && this.enemyCardsOut[CardIds.Collectible.Mage.Spellbender] >= 2)
                {
                    sec.canBe_spellbender = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.Vaporize) && this.enemyCardsOut[CardIds.Collectible.Mage.Vaporize] >= 2)
                {
                    sec.canBe_vaporize = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.Duplicate) && this.enemyCardsOut[CardIds.Collectible.Mage.Duplicate] >= 2)
                {
                    sec.canBe_duplicate = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Mage.Effigy) && this.enemyCardsOut[CardIds.Collectible.Mage.Effigy] >= 2)
                {
                    sec.canBe_effigy = false;
                }
            }

            if (SecClass == CardClass.PALADIN)
            {
                sec.canBe_snaketrap = false;
                sec.canBe_snipe = false;
                sec.canBe_explosive = false;
                sec.canBe_beartrap = false;
                sec.canBe_freezing = false;
                sec.canBe_missdirection = false;
                sec.canBe_darttrap = false;
                sec.canBe_cattrick = false;

                sec.canBe_counterspell = false;
                sec.canBe_icebarrier = false;
                sec.canBe_iceblock = false;
                sec.canBe_mirrorentity = false;
                sec.canBe_spellbender = false;
                sec.canBe_vaporize = false;
                sec.canBe_duplicate = false;
                sec.canBe_effigy = false;

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Paladin.EyeForAnEye) && this.enemyCardsOut[CardIds.Collectible.Paladin.EyeForAnEye] >= 2)
                {
                    sec.canBe_eyeforaneye = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Paladin.NobleSacrifice) && this.enemyCardsOut[CardIds.Collectible.Paladin.NobleSacrifice] >= 2)
                {
                    sec.canBe_noblesacrifice = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Paladin.Redemption) && this.enemyCardsOut[CardIds.Collectible.Paladin.Redemption] >= 2)
                {
                    sec.canBe_redemption = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Paladin.Repentance) && this.enemyCardsOut[CardIds.Collectible.Paladin.Repentance] >= 2)
                {
                    sec.canBe_repentance = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Paladin.Avenge) && this.enemyCardsOut[CardIds.Collectible.Paladin.Avenge] >= 2)
                {
                    sec.canBe_avenge = false;
                }

                if (this.enemyCardsOut.ContainsKey(CardIds.Collectible.Paladin.SacredTrial) && this.enemyCardsOut[CardIds.Collectible.Paladin.SacredTrial] >= 2)
                {
                    sec.canBe_sacredtrial = false;
                }
            }

            return sec;
        }


        public bool isAllowedSecret(SimCard cardID)
        {
            if (this.ownCardsOut.ContainsKey(cardID) && this.ownCardsOut[cardID] >= 2)
            {
                return false;
            }

            return true;
        }


        public string getEnemySecretData()
        {
            var retval = "";
            foreach (var si in this.enemySecrets)
            {
                retval += si.returnAString();
            }

            return retval;
        }

        public string getEnemySecretData(List<SecretItem> list)
        {
            var retval = "";
            foreach (var si in list)
            {
                retval += si.returnAString();
            }

            return retval;
        }


        public void setEnemySecretData(List<SecretItem> enemySecretl)
        {
            this.enemySecrets.Clear();
            foreach (var si in enemySecretl)
            {
                this.enemySecrets.Add(new SecretItem(si));
            }
        }

        public void updateSecretList(List<SecretItem> enemySecretl)
        {
            var temp = new List<SecretItem>();
            foreach (var si in this.enemySecrets)
            {
                var add = false;
                SecretItem seit = null;
                foreach (var sit in enemySecretl) // enemySecrets have to be updated to latest entitys
                {
                    if (si.entityId == sit.entityId)
                    {
                        seit = sit;
                        add = true;
                    }
                }

                temp.Add(add ? new SecretItem(seit) : new SecretItem(si));
            }

            this.enemySecrets.Clear();
            this.enemySecrets.AddRange(temp);
        }


        public void updateSecretList(Playfield p, Playfield old)
        {
            if (p.enemySecretCount == 0 || p.optionsPlayedThisTurn == 0)
            {
                return;
            }

            var doneMove = Ai.Instance.bestmove;
            if (doneMove == null)
            {
                return;
            }

            var enemySecretsOpenedStep = new List<SimCard>();
            var enemyMinionsDiedStep = new List<SimCard>();
            foreach (var tmp in p.enemyCardsOut)
            {
                if (!old.enemyCardsOut.ContainsKey(tmp.Key) || old.enemyCardsOut[tmp.Key] != tmp.Value)
                {
                    var c = tmp.Key;
                    if (c.Secret)
                    {
                        enemySecretsOpenedStep.Add(tmp.Key);
                    }
                    else if (c.Type == CardType.MINION)
                    {
                        enemyMinionsDiedStep.Add(c);
                    }
                }
            }

            var beartrap = false;
            var explosive = false;
            var snaketrap = false;
            var missdirection = false;
            var freezing = false;
            var snipe = false;
            var darttrap = false;
            var cattrick = false;

            var mirrorentity = false;
            var counterspell = false;
            var spellbender = false;
            var iceblock = false;
            var icebarrier = false;
            var vaporize = false;
            var duplicate = false;
            var effigy = false;

            var eyeforaneye = false;
            var noblesacrifice = false;
            var redemption = false;
            var repentance = false;
            var avenge = false;
            var sacredtrial = false;

            if (enemyMinionsDiedStep.Count > 0)
            {
                duplicate = true;

                if (old.enemyMinions.Count > 1)
                {
                    avenge = true;
                }

                if (old.enemyMinions.Count < 7)
                {
                    effigy = true;
                    redemption = true;
                }
                else if (!enemyMinionsDiedStep[0].Deathrattle)
                {
                    redemption = true;
                    effigy = true;
                }
                else
                {
                    switch (enemyMinionsDiedStep[0].CardId)
                    {
                        case CardIds.Collectible.Warlock.Dreadsteed:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Rogue.Anubarak:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.NonCollectible.Neutral.MoiraBronzebeard2:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.CairneBloodhoof:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Hunter.SavannahHighmane:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.HarvestGolem:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.HauntedCreeper:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.NerubianEgg:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.SludgeBelcher:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.PilotedShredder:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.PilotedSkyGolem:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.SneedsOldShredder:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Druid.MountedRaptor:
                            redemption = false;
                            effigy = false;
                            break;
                        case CardIds.Collectible.Neutral.WobblingRunts:
                            redemption = false;
                            effigy = false;
                            break;
                        default:
                            redemption = true;
                            effigy = true;
                            break;
                    }
                }
            }


            var targetWasHero = doneMove.target != null && doneMove.target.entitiyID == p.enemyHero.entitiyID;

            if (doneMove.actionType == actionEnum.attackWithHero || doneMove.actionType == actionEnum.attackWithMinion)
            {
                var attackerIsHero = doneMove.own.isHero;

                if (enemySecretsOpenedStep.Count == 0)
                {
                    if (old.enemyMinions.Count < 7)
                    {
                        noblesacrifice = true;
                    }

                    if (doneMove.actionType == actionEnum.attackWithMinion)
                    {
                        freezing = true;
                    }

                    if (targetWasHero)
                    {
                        explosive = true;
                        if (old.enemyMinions.Count < 7)
                        {
                            beartrap = true;
                        }

                        missdirection = true;
                        if (attackerIsHero && old.ownMinions.Count == 0 && old.enemyMinions.Count == 0)
                        {
                            missdirection = false;
                        }

                        icebarrier = true;
                        if (!attackerIsHero)
                        {
                            vaporize = true;
                        }
                    }
                    else
                    {
                        snaketrap = true;
                    }
                }
                else
                {
                    if (targetWasHero)
                    {
                        explosive = true;
                        icebarrier = true;
                        if (!attackerIsHero)
                        {
                            vaporize = true; //?
                        }
                    }
                    else
                    {
                        snaketrap = true;
                    }

                    if (!attackerIsHero)
                    {
                        freezing = true;
                    }

                    if (old.enemyMinions.Count < 7)
                    {
                        noblesacrifice = true;
                    }

                    foreach (var id in enemySecretsOpenedStep)
                    {
                        switch (id.CardId)
                        {
                            case CardIds.Collectible.Hunter.BearTrap: //beartrap
                                beartrap = true;
                                missdirection = true;
                                continue;
                            case CardIds.Collectible.Hunter.ExplosiveTrap: //explosivetrap
                                if (enemySecretsOpenedStep.Count == 1)
                                {
                                    missdirection = true;
                                    if (!attackerIsHero && p.ownMinions.Find(x => x.entitiyID == doneMove.own.entitiyID) == null)
                                    {
                                        missdirection = false;
                                        freezing = false;
                                    }
                                }

                                continue;
                            case CardIds.Collectible.Hunter.Misdirection: //misdirection
                                missdirection = true;
                                vaporize = false;
                                if (enemySecretsOpenedStep.Contains(CardIds.Collectible.Hunter.SnakeTrap))
                                {
                                    continue;
                                }

                                var hpBalance = 0; //we need to know who has become the new target
                                foreach (var m in p.enemyMinions)
                                {
                                    hpBalance += m.Hp;
                                }

                                foreach (var m in old.enemyMinions)
                                {
                                    hpBalance -= m.Hp;
                                }

                                if (hpBalance < 0)
                                {
                                    snaketrap = true;
                                }

                                continue;
                            case CardIds.Collectible.Hunter.FreezingTrap: //freezingtrap
                                freezing = true;
                                vaporize = false;
                                continue;
                            case CardIds.Collectible.Mage.Vaporize: //vaporize
                                vaporize = true;
                                freezing = false;
                                continue;
                            case CardIds.Collectible.Paladin.NobleSacrifice: //noblesacrifice
                                noblesacrifice = true;
                                snaketrap = true;
                                vaporize = false;
                                icebarrier = false;
                                continue;
                        }
                    }
                }
            }
            else if (doneMove.actionType == actionEnum.playcard)
            {
                if (doneMove.card.card.Type == CardType.SPELL)
                {
                    cattrick = true;
                    counterspell = true;
                    if (!targetWasHero)
                    {
                        spellbender = true;
                    }
                }

                /* else if (doneMove.card.card.type == CardType.MINION) //we need the response from the core
                 {
                     mirrorentity = true;
                     snipe = true;
                     repentance = true;
                     if (p.ownMinions.Count > 3) sacredtrial = true;
                 }*/
            }

            if (p.mobsplayedThisTurn > old.mobsplayedThisTurn) //if we have a response from the core - remove
            {
                mirrorentity = true;
                snipe = true;
                repentance = true;
                if (p.ownMinions.Count > 3)
                {
                    sacredtrial = true;
                }
            }

            if (p.enemyHero.Hp + p.enemyHero.armor < old.enemyHero.Hp + old.enemyHero.armor)
            {
                eyeforaneye = true;
            }

            if (doneMove.actionType == actionEnum.useHeroPower)
            {
                darttrap = true;
            }

            foreach (var id in enemySecretsOpenedStep)
            {
                switch (id.CardId)
                {
                    case CardIds.Collectible.Mage.Effigy:
                        effigy = true;
                        continue;
                    case CardIds.Collectible.Hunter.BearTrap:
                        beartrap = true;
                        continue;
                    case CardIds.Collectible.Paladin.NobleSacrifice:
                        noblesacrifice = true;
                        continue;
                    case CardIds.Collectible.Paladin.EyeForAnEye:
                        eyeforaneye = true;
                        continue;
                    case CardIds.Collectible.Paladin.Redemption:
                        redemption = true;
                        continue;
                    case CardIds.Collectible.Mage.Counterspell:
                        counterspell = true;
                        continue;
                    case CardIds.Collectible.Mage.IceBarrier:
                        icebarrier = true;
                        continue;
                    case CardIds.Collectible.Mage.MirrorEntity:
                        mirrorentity = true;
                        continue;
                    case CardIds.Collectible.Mage.IceBlock:
                        iceblock = true;
                        continue;
                    case CardIds.Collectible.Paladin.Repentance:
                        repentance = true;
                        continue;
                    case CardIds.Collectible.Hunter.Misdirection:
                        missdirection = true;
                        continue;
                    case CardIds.Collectible.Hunter.SnakeTrap:
                        snaketrap = true;
                        continue;
                    case CardIds.Collectible.Mage.Vaporize:
                        vaporize = true;
                        continue;
                    case CardIds.Collectible.Hunter.Snipe:
                        snipe = true;
                        continue;
                    case CardIds.Collectible.Hunter.ExplosiveTrap:
                        explosive = true;
                        continue;
                    case CardIds.Collectible.Hunter.FreezingTrap:
                        freezing = true;
                        continue;
                    case CardIds.Collectible.Mage.Duplicate:
                        duplicate = true;
                        continue;
                    case CardIds.Collectible.Paladin.Avenge:
                        avenge = true;
                        continue;
                    case CardIds.Collectible.Hunter.DartTrap:
                        darttrap = true;
                        continue;
                    case CardIds.Collectible.Paladin.SacredTrial:
                        sacredtrial = true;
                        continue;
                    case CardIds.Collectible.Mage.Spellbender:
                        spellbender = true;
                        continue;
                    case CardIds.Collectible.Hunter.CatTrick:
                        cattrick = true;
                        continue;
                }
            }

            foreach (var si in this.enemySecrets)
            {
                if (beartrap)
                {
                    si.canBe_beartrap = false;
                }

                if (explosive)
                {
                    si.canBe_explosive = false;
                }

                if (snaketrap)
                {
                    si.canBe_snaketrap = false;
                }

                if (missdirection)
                {
                    si.canBe_missdirection = false;
                }

                if (freezing)
                {
                    si.canBe_freezing = false;
                }

                if (snipe)
                {
                    si.canBe_snipe = false;
                }

                if (darttrap)
                {
                    si.canBe_darttrap = false;
                }

                if (cattrick)
                {
                    si.canBe_cattrick = false;
                }

                if (counterspell)
                {
                    si.canBe_counterspell = false;
                }

                if (icebarrier)
                {
                    si.canBe_icebarrier = false;
                }

                if (iceblock)
                {
                    si.canBe_iceblock = false;
                }

                if (mirrorentity)
                {
                    si.canBe_mirrorentity = false;
                }

                if (spellbender)
                {
                    si.canBe_spellbender = false;
                }

                if (vaporize)
                {
                    si.canBe_vaporize = false;
                }

                if (duplicate)
                {
                    si.canBe_duplicate = false;
                }

                if (effigy)
                {
                    si.canBe_effigy = false;
                }

                if (eyeforaneye)
                {
                    si.canBe_eyeforaneye = false;
                }

                if (noblesacrifice)
                {
                    si.canBe_noblesacrifice = false;
                }

                if (redemption)
                {
                    si.canBe_redemption = false;
                }

                if (repentance)
                {
                    si.canBe_repentance = false;
                }

                if (avenge)
                {
                    si.canBe_avenge = false;
                }

                if (sacredtrial)
                {
                    si.canBe_sacredtrial = false;
                }
            }
        }
    }
}