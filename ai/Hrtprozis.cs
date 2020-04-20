using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;
using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    public class Hrtprozis
    {
        public int pId = 0;
        public int attackFaceHp = 15;
        public int ownHeroFatigue = 0;
        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int enemyHeroFatigue = 0;
        public int gTurn = 0;
        public int gTurnStep = 0;

        public int ownHeroEntity = -1;
        public int enemyHeroEntitiy = -1;
        public DateTime roundstart = DateTime.Now;
        public int currentMana = 0;

        public int heroHp = 30, enemyHp = 30;
        public int heroAtk = 0, enemyAtk = 0;
        public int heroDefence = 0, enemyDefence = 0;
        public bool ownheroisread = false;
        public int ownHeroNumAttacksThisTurn = 0;
        public bool ownHeroWindfury = false;
        public bool herofrozen = false;
        public bool enemyfrozen = false;

        public List<SimCard> ownSecretList = new List<SimCard>();
        public int enemySecretCount = 0;
        public Dictionary<int, SimCard> DiscoverCards = new Dictionary<int, SimCard>();
        public Dictionary<SimCard, int> turnDeck = new Dictionary<SimCard, int>();
        private Dictionary<int, SimCard> deckCardForCost = new Dictionary<int, SimCard>();
        public bool noDuplicates = false;

        private int numTauntCards = -1;
        private int numDivineShieldCards = -1;
        private int numLifestealCards = -1;
        private int numWindfuryCards = -1;

        public bool setGameRule = false;

        public string heronameingame = "", enemyHeroingame = "";
        public CardClass ownHeroStartClass;
        public CardClass enemyHeroStartClass;
        public SimCard heroAbility;
        public bool ownAbilityisReady = false;
        public int ownHeroPowerCost = 2;
        public SimCard enemyAbility;
        public int enemyHeroPowerCost = 2;
        public int numOptionsPlayedThisTurn = 0;
        public int numMinionsPlayedThisTurn = 0;
        public SimCard OwnLastDiedMinion = SimCard.None;

        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0;
        public int lockedMana = 0;

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public Minion ownHero = new Minion();
        public Minion enemyHero = new Minion();
        public Weapon ownWeapon = new Weapon();
        public Weapon enemyWeapon = new Weapon();
        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();

        public int anzOgOwnCThunHpBonus = 0;
        public int anzOgOwnCThunAngrBonus = 0;
        public int anzOgOwnCThunTaunt = 0;
        public int anzOwnJadeGolem = 0;
        public int anzEnemyJadeGolem = 0;
        public int ownCrystalCore = 0;
        public bool ownMinionsInDeckCost0 = false;
        public int anzOwnElementalsThisTurn = 0;
        public int anzOwnElementalsLastTurn = 0;
        public int ownElementalsHaveLifesteal = 0;
        private int ownPlayerController = 0;

        public PenalityManager penman;
        public Settings settings;
        Helpfunctions help;

        private static Hrtprozis instance;

        public static Hrtprozis Instance
        {
            get
            {
                return instance ?? (instance = new Hrtprozis());
            }
        }

        public void setInstances()
        {
            help = Helpfunctions.Instance;
            penman = PenalityManager.Instance;
            settings = Settings.Instance;
        }

        private Hrtprozis()
        {
        }

        public void setAttackFaceHP(int hp)
        {
            this.attackFaceHp = hp;
        }

        public int getPid()
        {
            return pId++;
        }

        public void clearAllNewGame()
        {
            this.ownHeroStartClass = CardClass.INVALID;
            this.enemyHeroStartClass = CardClass.INVALID;
            this.setGameRule = false;
            this.clearAllRecalc();
        }

        public void clearAllRecalc()
        {
            pId = 0;
            ownHeroEntity = -1;
            enemyHeroEntitiy = -1;
            currentMana = 0;
            heroHp = 30;
            enemyHp = 30;
            heroAtk = 0;
            enemyAtk = 0;
            heroDefence = 0; enemyDefence = 0;
            ownheroisread = false;
            ownAbilityisReady = false;
            ownHeroNumAttacksThisTurn = 0;
            ownHeroWindfury = false;
            ownSecretList.Clear();
            enemySecretCount = 0;
            heroname = CardClass.INVALID;
            enemyHero.CardClass = CardClass.INVALID;
            heronameingame = "";
            enemyHeroingame = "";
            heroAbility = new SimCard();
            enemyAbility = new SimCard();
            herofrozen = false;
            enemyfrozen = false;
            numMinionsPlayedThisTurn = 0;
            cardsPlayedThisTurn = 0;
            ueberladung = 0;
            lockedMana = 0;
            ownMaxMana = 0;
            enemyMaxMana = 0;
            ownWeapon = new Weapon();
            enemyWeapon = new Weapon();
            ownMinions.Clear();
            enemyMinions.Clear();
            noDuplicates = false;
            deckCardForCost.Clear();
            turnDeck.Clear();
        }


        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        public int getOwnController()
        {
            return this.ownPlayerController;
        }

        public void updateJadeGolemsInfo(int anzOwnJG, int anzEmemyJG)
        {
            anzOwnJadeGolem = anzOwnJG;
            anzEnemyJadeGolem = anzEmemyJG;
        }

        public void updateCrystalCore(int num)
        {
            ownCrystalCore = num;
        }

        public void updateOwnMinionsInDeckCost0(bool tmp)
        {
            ownMinionsInDeckCost0 = tmp;
        }

        public void updateElementals(int anzOwnElemTT, int anzOwnElemLT, int ownElementalsHaveLS)
        {
            anzOwnElementalsThisTurn = anzOwnElemTT;
            anzOwnElementalsLastTurn = anzOwnElemLT;
            ownElementalsHaveLifesteal = ownElementalsHaveLS;
        }

        public string heroIDtoName(string s)
        {
            switch (s)
            {
                case "HERO_01": return "warrior";
                case "HERO_01a": return "warrior";
                case "ICC_834": return "warrior";
                case "HERO_02": return "shaman";
                case "HERO_02a": return "shaman";
                case "ICC_481": return "shaman";
                case "HERO_03": return "thief";
                case "HERO_03a": return "thief";
                case "ICC_827": return "thief";
                case "HERO_04": return "pala";
                case "HERO_04a": return "pala";
                case "HERO_04b": return "pala";
                case "ICC_829": return "pala";
                case "HERO_05": return "hunter";
                case "HERO_05a": return "hunter";
                case "ICC_828": return "hunter";
                case "HERO_06": return "druid";
                case "ICC_832": return "druid";
                case "HERO_07": return "warlock";
                case "HERO_07a": return "warlock";
                case "ICC_831": return "warlock";
                case "HERO_08": return "mage";
                case "HERO_08a": return "mage";
                case "HERO_08b": return "mage";
                case "ICC_833": return "mage";
                case "HERO_09": return "priest";
                case "HERO_09a": return "priest";
                case "ICC_830": return "priest";
                case "EX1_323h": return "lordjaraxxus";
                case "BRM_027h": return "ragnarosthefirelord";
                default:
                    return s;
            }
        }

        public void updateMinions(List<Minion> om, List<Minion> em)
        {
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            foreach (var item in om)
            {
                this.ownMinions.Add(new Minion(item));
            }
            //this.ownMinions.AddRange(om);
            foreach (var item in em)
            {
                this.enemyMinions.Add(new Minion(item));
            }
            //this.enemyMinions.AddRange(em);

            //sort them
            updatePositions();
        }

        public void updateLurkersDB(Dictionary<int, IDEnumOwner> ldb)
        {
            this.LurkersDB.Clear();
            foreach (KeyValuePair<int, IDEnumOwner> lt in ldb)
            {
                this.LurkersDB.Add(lt.Key, lt.Value);
            }
        }

        public void updateSecretStuff(List<string> ownsecs, int numEnemSec)
        {
            this.ownSecretList.Clear();
            foreach (string s in ownsecs)
            {
                this.ownSecretList.Add(s);
            }
            this.enemySecretCount = numEnemSec;
        }

        public void updateTurnDeck(Dictionary<SimCard, int> deck, bool noDupl)
        {
            this.turnDeck.Clear();
            foreach (KeyValuePair<SimCard, int> c in deck)
            {
                this.turnDeck.Add(c.Key, c.Value);
            }
            this.noDuplicates = noDupl;
            deckCardForCost.Clear();
        }

        public SimCard getDeckCardsForCost(int cost)
        {
            if (deckCardForCost.Count == 0)
            {
                SimCard c;
                foreach (KeyValuePair<SimCard, int> cn in turnDeck)
                {
                    c = cn.Key;
                    if (!deckCardForCost.ContainsKey(c.Cost)) deckCardForCost.Add(c.Cost, c);
                }
            }
            if (deckCardForCost.ContainsKey(cost)) return deckCardForCost[cost];
            else return SimCard.None;
        }

        public int numDeckCardsByTag(GameTag tag)
        {
            switch (tag)
            {
                case GameTag.TAUNT: if (numTauntCards > -1) return numTauntCards; break;
                case GameTag.DIVINE_SHIELD: if (numDivineShieldCards > -1) return numDivineShieldCards; break;
                case GameTag.LIFESTEAL: if (numLifestealCards > -1) return numLifestealCards; break;
                case GameTag.WINDFURY: if (numWindfuryCards > -1) return numWindfuryCards; break;
            }
            numTauntCards = 0;
            numDivineShieldCards = 0;
            numLifestealCards = 0;
            numWindfuryCards = 0;

            SimCard c;
            foreach (KeyValuePair<SimCard, int> cn in turnDeck)
            {
                c = (cn.Key);
                if (c.Taunt) numTauntCards += cn.Value;
                if (c.DivineShield) numDivineShieldCards += cn.Value;
                if (c.Lifesteal) numLifestealCards += cn.Value;
                if (c.Windfury) numWindfuryCards += cn.Value;
            }

            switch (tag)
            {
                case GameTag.TAUNT: return numTauntCards;
                case GameTag.DIVINE_SHIELD: return numDivineShieldCards;
                case GameTag.LIFESTEAL: return numLifestealCards;
                case GameTag.WINDFURY: return numWindfuryCards;
            }
            return -1;
        }

        public void updatePlayer(int maxmana, int currentmana, int cardsplayedthisturn, int numMinionsplayed, int optionsPlayedThisTurn, int overload, int lockedmana, int heroentity, int enemyentity)
        {
            this.currentMana = currentmana;
            this.ownMaxMana = maxmana;
            this.cardsPlayedThisTurn = cardsplayedthisturn;
            this.numMinionsPlayedThisTurn = numMinionsplayed;
            this.ueberladung = overload;
            this.lockedMana = lockedmana;
            this.ownHeroEntity = heroentity;
            this.enemyHeroEntitiy = enemyentity;
            this.numOptionsPlayedThisTurn = optionsPlayedThisTurn;
        }

        public void updateHeroStartClass(CardClass ownHSClass, CardClass enemyHSClass)
        {
            this.ownHeroStartClass = ownHSClass;
            this.enemyHeroStartClass = enemyHSClass;
        }


        public void updateHero(Weapon w, CardClass heron, SimCard ability, bool abrdy, int abCost, Minion hero, int enMaxMana = 10)
        {
            if (w.name == CardIds.Collectible.Warrior.FoolsBane) w.cantAttackHeroes = true;

            if (hero.own)
            {
                this.ownWeapon = new Weapon(w);

                this.ownHero = new Minion(hero);
                this.heronameingame = heron;
                if (this.ownHeroStartClass == CardClass.INVALID) this.ownHeroStartClass = hero.CardClass;
                this.ownHero.poisonous = this.ownWeapon.poisonous;
                this.ownHero.lifesteal = this.ownWeapon.lifesteal;
                if (this.ownWeapon.name == CardIds.Collectible.Hunter.GladiatorsLongbow) this.ownHero.immuneWhileAttacking = true;

                this.heroAbility = ability;
                this.ownHeroPowerCost = abCost;
                this.ownAbilityisReady = abrdy;
            }
            else
            {
                this.enemyWeapon = new Weapon(w);
                this.enemyHero = new Minion(hero);;

                this.enemyHeroingame = heron;
                if (this.enemyHeroStartClass == CardClass.INVALID) this.enemyHeroStartClass = enemyHero.CardClass;
                this.enemyHero.poisonous = this.enemyWeapon.poisonous;
                this.enemyHero.lifesteal = this.enemyWeapon.lifesteal;
                if (this.enemyWeapon.name == CardIds.Collectible.Hunter.GladiatorsLongbow) this.enemyHero.immuneWhileAttacking = true;

                this.enemyAbility = ability;
                this.enemyHeroPowerCost = abCost;

                this.enemyMaxMana = enMaxMana;
            }
        }

        public void updateTurnInfo(int turn, int step)
        {
            this.gTurn = turn;
            this.gTurnStep = step;
        }

        public void updateCThunInfo(int OgOwnCThunAngrBonus, int OgOwnCThunHpBonus, int OgOwnCThunTaunt)
        {
            this.anzOgOwnCThunAngrBonus = OgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = OgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = OgOwnCThunTaunt;
        }

        public void updateFatigueStats(int ods, int ohf, int eds, int ehf)
        {
            this.ownDeckSize = ods;
            this.ownHeroFatigue = ohf;
            this.enemyDeckSize = eds;
            this.enemyHeroFatigue = ehf;
        }

        public void updatePositions()
        {
            this.ownMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            this.enemyMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            int i = 0;
            foreach (Minion m in this.ownMinions)
            {
                i++;
                m.zonepos = i;

            }
            i = 0;
            foreach (Minion m in this.enemyMinions)
            {
                i++;
                m.zonepos = i;
            }

        }

        public void updateDiscoverCards(List<string> discoverCardsList)
        {
            if (discoverCardsList.Count == 4)
            {
                this.DiscoverCards.Clear();
                for (int i = 0; i < 3; i++)
                {
                    this.DiscoverCards.Add(i, discoverCardsList[i + 1]);
                }
            }
        }

        public void updateOwnLastDiedMinion(SimCard cid)
        {
            this.OwnLastDiedMinion = cid;
        }

        private Minion createNewMinion(Handmanager.Handcard hc, int id)
        {
            Minion m = new Minion
            {
                handcard = new Handmanager.Handcard(hc),
                zonepos = id + 1,
                entitiyID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };


            if (hc.card.Windfury) m.windfury = true;
            if (hc.card.Taunt) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = 1;
            }
            if (hc.card.DivineShield) m.divineshild = true;
            if (hc.card.Poisonous) m.poisonous = true;
            if (hc.card.Lifesteal) m.lifesteal = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == CardIds.Collectible.Priest.Lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            return m;
        }

        public void printHero()
        {
            help.logg("player:");
            help.logg(this.numMinionsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.ueberladung + " " + this.lockedMana + " " + this.ownPlayerController);

            help.logg("ownhero:");
            help.logg((this.heroname == CardClass.INVALID ? this.heronameingame : this.heroname.ToString()) + " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " " + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entitiyID + " " + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " " + this.ownHero.Angr + " " + this.ownHero.tempAttack + " " + this.enemyHero.stealth);
            help.logg("weapon: " + ownWeapon.Angr + " " + ownWeapon.Durability + " " + this.ownWeapon.name + " " + this.ownWeapon.card.CardId + " " + (this.ownWeapon.poisonous ? 1 : 0) + " " + (this.ownWeapon.lifesteal ? 1 : 0));
            help.logg("ability: " + this.ownAbilityisReady + " " + this.heroAbility.CardId);
            string secs = "";
            foreach (SimCard sec in this.ownSecretList)
            {
                secs += sec + " ";
            }
            help.logg("osecrets: " + secs);
            help.logg("cthunbonus: " + this.anzOgOwnCThunAngrBonus + " " + this.anzOgOwnCThunHpBonus + " " + this.anzOgOwnCThunTaunt);
            help.logg("jadegolems: " + this.anzOwnJadeGolem + " " + this.anzEnemyJadeGolem);
            help.logg("elementals: " + this.anzOwnElementalsThisTurn + " " + this.anzOwnElementalsLastTurn + " " + this.ownElementalsHaveLifesteal);
            help.logg(Questmanager.Instance.getQuestsString());
            help.logg("advanced: " + this.ownCrystalCore + " " + (this.ownMinionsInDeckCost0 ? 1: 0));
            help.logg("enemyhero:");
            help.logg((this.enemyHero.CardClass == CardClass.INVALID ? this.enemyHeroingame : this.enemyHero.CardClass.ToString()) + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " " + this.enemyHero.armor + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " " + this.enemyHero.entitiyID + " " + this.enemyHero.stealth);
            help.logg("weapon: " + this.enemyWeapon.Angr + " " + this.enemyWeapon.Durability + " " + this.enemyWeapon.name + " " + this.enemyWeapon.card.CardId + " " + (this.enemyWeapon.poisonous ? 1 : 0) + " " + (this.enemyWeapon.lifesteal ? 1 : 0));
            help.logg("ability: " + "True" + " " + this.enemyAbility.CardId);
            help.logg("fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " " + this.enemyHeroFatigue);
        }


        public void printOwnMinions()
        {
            help.logg("OwnMinions:");
            foreach (Minion m in this.ownMinions)
            {
                string mini = m.name + " " + m.handcard.card.CardId + " zp:" + m.zonepos + " e:" + m.entitiyID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready + " natt:" + m.numAttacksThisTurn;
                if (m.exhausted) mini += " ex";
                if (m.taunt) mini += " tnt";
                if (m.frozen) mini += " frz";
                if (m.silenced) mini += " silenced";
                if (m.divineshild) mini += " divshield";
                if (m.playedThisTurn) mini += " ptt";
                if (m.windfury) mini += " wndfr";
                if (m.stealth) mini += " stlth";
                if (m.poisonous) mini += " poi";
                if (m.lifesteal) mini += " lfst";
                if (m.immune) mini += " imm";
                if (m.untouchable) mini += " untch";
                if (m.conceal) mini += " cncdl";
                if (m.destroyOnOwnTurnStart) mini += " dstrOwnTrnStrt";
                if (m.destroyOnOwnTurnEnd) mini += " dstrOwnTrnnd";
                if (m.destroyOnEnemyTurnStart) mini += " dstrEnmTrnStrt";
                if (m.destroyOnEnemyTurnEnd) mini += " dstrEnmTrnnd";
                if (m.shadowmadnessed) mini += " shdwmdnssd";
                if (m.cantLowerHPbelowONE) mini += " cantLowerHpBelowOne";
                if (m.cantBeTargetedBySpellsOrHeroPowers) mini += " cbtBySpells";

                if (m.charge >= 1) mini += " chrg(" + m.charge + ")";
                if (m.hChoice >= 1) mini += " hChoice(" + m.hChoice + ")";
                if (m.AdjacentAngr >= 1) mini += " adjaattk(" + m.AdjacentAngr + ")";
                if (m.tempAttack != 0) mini += " tmpattck(" + m.tempAttack + ")";
                if (m.spellpower != 0) mini += " spllpwr(" + m.spellpower + ")";

                if (m.ancestralspirit >= 1) mini += " ancstrl(" + m.ancestralspirit + ")";
                if (m.desperatestand >= 1) mini += " despStand(" + m.desperatestand + ")";
                if (m.ownBlessingOfWisdom >= 1) mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
                if (m.enemyBlessingOfWisdom >= 1) mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
                if (m.ownPowerWordGlory >= 1) mini += " ownGlory(" + m.ownPowerWordGlory + ")";
                if (m.enemyPowerWordGlory >= 1) mini += " enemyGlory(" + m.enemyPowerWordGlory + ")";
                if (m.souloftheforest >= 1) mini += " souloffrst(" + m.souloftheforest + ")";
                if (m.stegodon >= 1) mini += " stegodon(" + m.stegodon + ")";
                if (m.livingspores >= 1) mini += " lspores(" + m.livingspores + ")";
                if (m.explorershat >= 1) mini += " explHat(" + m.explorershat + ")";
                if (m.returnToHand >= 1) mini += " retHand(" + m.returnToHand + ")";
                if (m.infest >= 1) mini += " infest(" + m.infest + ")";
                if (m.deathrattle2 != null) mini += " dethrl(" + m.deathrattle2.CardId + ")";
                if (m.name == CardIds.Collectible.Neutral.MoatLurker && this.LurkersDB.ContainsKey(m.entitiyID))
                {
                    mini += " respawn:" + this.LurkersDB[m.entitiyID].IDEnum + ":" + this.LurkersDB[m.entitiyID].own;
                }

                help.logg(mini);
            }

        }

        public void printEnemyMinions()
        {
            help.logg("EnemyMinions:");
            foreach (Minion m in this.enemyMinions)
            {
                string mini = m.name + " " + m.handcard.card.CardId + " zp:" + m.zonepos + " e:" + m.entitiyID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready;// +" natt:" + m.numAttacksThisTurn;
                if (m.exhausted) mini += " ex";
                if (m.taunt) mini += " tnt";
                if (m.frozen) mini += " frz";
                if (m.silenced) mini += " silenced";
                if (m.divineshild) mini += " divshield";
                if (m.playedThisTurn) mini += " ptt";
                if (m.windfury) mini += " wndfr";
                if (m.stealth) mini += " stlth";
                if (m.poisonous) mini += " poi";
                if (m.lifesteal) mini += " lfst";
                if (m.immune) mini += " imm";
                if (m.untouchable) mini += " untch";
                if (m.conceal) mini += " cncdl";
                if (m.destroyOnOwnTurnStart) mini += " dstrOwnTrnStrt";
                if (m.destroyOnOwnTurnEnd) mini += " dstrOwnTrnnd";
                if (m.destroyOnEnemyTurnStart) mini += " dstrEnmTrnStrt";
                if (m.destroyOnEnemyTurnEnd) mini += " dstrEnmTrnnd";
                if (m.shadowmadnessed) mini += " shdwmdnssd";
                if (m.cantLowerHPbelowONE) mini += " cantLowerHpBelowOne";
                if (m.cantBeTargetedBySpellsOrHeroPowers) mini += " cbtBySpells";

                if (m.charge >= 1) mini += " chrg(" + m.charge + ")";
                if (m.hChoice >= 1) mini += " hChoice(" + m.hChoice + ")";
                if (m.AdjacentAngr >= 1) mini += " adjaattk(" + m.AdjacentAngr + ")";
                if (m.tempAttack != 0) mini += " tmpattck(" + m.tempAttack + ")";
                if (m.spellpower != 0) mini += " spllpwr(" + m.spellpower + ")";

                if (m.ancestralspirit >= 1) mini += " ancstrl(" + m.ancestralspirit + ")";
                if (m.desperatestand >= 1) mini += " despStand(" + m.desperatestand + ")";
                if (m.ownBlessingOfWisdom >= 1) mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
                if (m.enemyBlessingOfWisdom >= 1) mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
                if (m.ownPowerWordGlory >= 1) mini += " ownGlory(" + m.ownPowerWordGlory + ")";
                if (m.enemyPowerWordGlory >= 1) mini += " enemyGlory(" + m.enemyPowerWordGlory + ")";
                if (m.souloftheforest >= 1) mini += " souloffrst(" + m.souloftheforest + ")";
                if (m.stegodon >= 1) mini += " stegodon(" + m.stegodon + ")";
                if (m.livingspores >= 1) mini += " lspores(" + m.livingspores + ")";
                if (m.explorershat >= 1) mini += " explHat(" + m.explorershat + ")";
                if (m.returnToHand >= 1) mini += " retHand(" + m.returnToHand + ")";
                if (m.infest >= 1) mini += " infest(" + m.infest + ")";
                if (m.deathrattle2 != null) mini += " dethrl(" + m.deathrattle2.CardId + ")";
                if (m.name == CardIds.Collectible.Neutral.MoatLurker && this.LurkersDB.ContainsKey(m.entitiyID))
                {
                    mini += " respawn:" + this.LurkersDB[m.entitiyID].IDEnum + ":" + this.LurkersDB[m.entitiyID].own;
                }

                help.logg(mini);
            }

        }

        public void printOwnDeck()
        {
            string od = "od: ";
            foreach (KeyValuePair<SimCard, int> e in this.turnDeck)
            {
                od += e.Key + "," + e.Value + ";";
            }
            Helpfunctions.Instance.logg(od);
        }

    }

}