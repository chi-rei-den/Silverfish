using System;
using System.Collections.Generic;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class Hrtprozis
    {
        public int pId;
        public int attackFaceHp = 15;
        public int ownHeroFatigue;
        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int enemyHeroFatigue;
        public int gTurn;
        public int gTurnStep;

        public int ownHeroEntity = -1;
        public int enemyHeroEntitiy = -1;
        public DateTime roundstart = DateTime.Now;
        public int currentMana;

        public int heroHp = 30, enemyHp = 30;
        public int heroAtk, enemyAtk;
        public int heroDefence, enemyDefence;
        public bool ownheroisread;
        public int ownHeroNumAttacksThisTurn;
        public bool ownHeroWindfury;
        public bool herofrozen;
        public bool enemyfrozen;

        public List<SimCard> ownSecretList = new List<SimCard>();
        public int enemySecretCount;
        public Dictionary<int, SimCard> DiscoverCards = new Dictionary<int, SimCard>();
        public Dictionary<SimCard, int> turnDeck = new Dictionary<SimCard, int>();
        private Dictionary<int, SimCard> deckCardForCost = new Dictionary<int, SimCard>();
        public bool noDuplicates;

        private int numTauntCards = -1;
        private int numDivineShieldCards = -1;
        private int numLifestealCards = -1;
        private int numWindfuryCards = -1;

        public bool setGameRule;

        public CardClass ownHeroStartClass;
        public CardClass enemyHeroStartClass;
        public SimCard heroAbility;
        public bool ownAbilityisReady;
        public int ownHeroPowerCost = 2;
        public SimCard enemyAbility;
        public int enemyHeroPowerCost = 2;
        public int numOptionsPlayedThisTurn;
        public int numMinionsPlayedThisTurn;
        public SimCard OwnLastDiedMinion = SimCard.None;

        public int cardsPlayedThisTurn;
        public int ueberladung;
        public int lockedMana;

        public int ownMaxMana;
        public int enemyMaxMana;

        public Minion ownHero = new Minion();
        public Minion enemyHero = new Minion();
        public Weapon ownWeapon = new Weapon();
        public Weapon enemyWeapon = new Weapon();
        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();

        public int anzOgOwnCThunHpBonus;
        public int anzOgOwnCThunAngrBonus;
        public int anzOgOwnCThunTaunt;
        public int anzOwnJadeGolem;
        public int anzEnemyJadeGolem;
        public int ownCrystalCore;
        public bool ownMinionsInDeckCost0;
        public int anzOwnElementalsThisTurn;
        public int anzOwnElementalsLastTurn;
        public int ownElementalsHaveLifesteal;
        private int ownPlayerController;

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
            this.help = Helpfunctions.Instance;
            this.penman = PenalityManager.Instance;
            this.settings = Settings.Instance;
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
            return this.pId++;
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
            this.pId = 0;
            this.ownHeroEntity = -1;
            this.enemyHeroEntitiy = -1;
            this.currentMana = 0;
            this.heroHp = 30;
            this.enemyHp = 30;
            this.heroAtk = 0;
            this.enemyAtk = 0;
            this.heroDefence = 0;
            this.enemyDefence = 0;
            this.ownheroisread = false;
            this.ownAbilityisReady = false;
            this.ownHeroNumAttacksThisTurn = 0;
            this.ownHeroWindfury = false;
            this.ownSecretList.Clear();
            this.enemySecretCount = 0;
            this.enemyHero.CardClass = CardClass.INVALID;
            this.heroAbility = new SimCard();
            this.enemyAbility = new SimCard();
            this.herofrozen = false;
            this.enemyfrozen = false;
            this.numMinionsPlayedThisTurn = 0;
            this.cardsPlayedThisTurn = 0;
            this.ueberladung = 0;
            this.lockedMana = 0;
            this.ownMaxMana = 0;
            this.enemyMaxMana = 0;
            this.ownWeapon = new Weapon();
            this.enemyWeapon = new Weapon();
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            this.noDuplicates = false;
            this.deckCardForCost.Clear();
            this.turnDeck.Clear();
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
            this.anzOwnJadeGolem = anzOwnJG;
            this.anzEnemyJadeGolem = anzEmemyJG;
        }

        public void updateCrystalCore(int num)
        {
            this.ownCrystalCore = num;
        }

        public void updateOwnMinionsInDeckCost0(bool tmp)
        {
            this.ownMinionsInDeckCost0 = tmp;
        }

        public void updateElementals(int anzOwnElemTT, int anzOwnElemLT, int ownElementalsHaveLS)
        {
            this.anzOwnElementalsThisTurn = anzOwnElemTT;
            this.anzOwnElementalsLastTurn = anzOwnElemLT;
            this.ownElementalsHaveLifesteal = ownElementalsHaveLS;
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
            this.updatePositions();
        }

        public void updateLurkersDB(Dictionary<int, IDEnumOwner> ldb)
        {
            this.LurkersDB.Clear();
            foreach (var lt in ldb)
            {
                this.LurkersDB.Add(lt.Key, lt.Value);
            }
        }

        public void updateSecretStuff(List<string> ownsecs, int numEnemSec)
        {
            this.ownSecretList.Clear();
            foreach (var s in ownsecs)
            {
                this.ownSecretList.Add(s);
            }

            this.enemySecretCount = numEnemSec;
        }

        public void updateTurnDeck(Dictionary<SimCard, int> deck, bool noDupl)
        {
            this.turnDeck.Clear();
            foreach (var c in deck)
            {
                this.turnDeck.Add(c.Key, c.Value);
            }

            this.noDuplicates = noDupl;
            this.deckCardForCost.Clear();
        }

        public SimCard getDeckCardsForCost(int cost)
        {
            if (this.deckCardForCost.Count == 0)
            {
                SimCard c;
                foreach (var cn in this.turnDeck)
                {
                    c = cn.Key;
                    if (!this.deckCardForCost.ContainsKey(c.Cost))
                    {
                        this.deckCardForCost.Add(c.Cost, c);
                    }
                }
            }

            if (this.deckCardForCost.ContainsKey(cost))
            {
                return this.deckCardForCost[cost];
            }

            return SimCard.None;
        }

        public int numDeckCardsByTag(GameTag tag)
        {
            switch (tag)
            {
                case GameTag.TAUNT:
                    if (this.numTauntCards > -1)
                    {
                        return this.numTauntCards;
                    }

                    break;
                case GameTag.DIVINE_SHIELD:
                    if (this.numDivineShieldCards > -1)
                    {
                        return this.numDivineShieldCards;
                    }

                    break;
                case GameTag.LIFESTEAL:
                    if (this.numLifestealCards > -1)
                    {
                        return this.numLifestealCards;
                    }

                    break;
                case GameTag.WINDFURY:
                    if (this.numWindfuryCards > -1)
                    {
                        return this.numWindfuryCards;
                    }

                    break;
            }

            this.numTauntCards = 0;
            this.numDivineShieldCards = 0;
            this.numLifestealCards = 0;
            this.numWindfuryCards = 0;

            SimCard c;
            foreach (var cn in this.turnDeck)
            {
                c = cn.Key;
                if (c.Taunt)
                {
                    this.numTauntCards += cn.Value;
                }

                if (c.DivineShield)
                {
                    this.numDivineShieldCards += cn.Value;
                }

                if (c.Lifesteal)
                {
                    this.numLifestealCards += cn.Value;
                }

                if (c.Windfury)
                {
                    this.numWindfuryCards += cn.Value;
                }
            }

            switch (tag)
            {
                case GameTag.TAUNT: return this.numTauntCards;
                case GameTag.DIVINE_SHIELD: return this.numDivineShieldCards;
                case GameTag.LIFESTEAL: return this.numLifestealCards;
                case GameTag.WINDFURY: return this.numWindfuryCards;
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
            if (w.name == CardIds.Collectible.Warrior.FoolsBane)
            {
                w.cantAttackHeroes = true;
            }

            if (hero.own)
            {
                this.ownWeapon = new Weapon(w);

                this.ownHero = new Minion(hero);
                this.ownHero.CardClass = heron;
                if (this.ownHeroStartClass == CardClass.INVALID)
                {
                    this.ownHeroStartClass = hero.CardClass;
                }

                this.ownHero.poisonous = this.ownWeapon.poisonous;
                this.ownHero.lifesteal = this.ownWeapon.lifesteal;
                if (this.ownWeapon.name == CardIds.Collectible.Hunter.GladiatorsLongbow)
                {
                    this.ownHero.immuneWhileAttacking = true;
                }

                this.heroAbility = ability;
                this.ownHeroPowerCost = abCost;
                this.ownAbilityisReady = abrdy;
            }
            else
            {
                this.enemyWeapon = new Weapon(w);
                this.enemyHero = new Minion(hero);
                ;

                this.enemyHero.CardClass = heron;
                if (this.enemyHeroStartClass == CardClass.INVALID)
                {
                    this.enemyHeroStartClass = this.enemyHero.CardClass;
                }

                this.enemyHero.poisonous = this.enemyWeapon.poisonous;
                this.enemyHero.lifesteal = this.enemyWeapon.lifesteal;
                if (this.enemyWeapon.name == CardIds.Collectible.Hunter.GladiatorsLongbow)
                {
                    this.enemyHero.immuneWhileAttacking = true;
                }

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
            var i = 0;
            foreach (var m in this.ownMinions)
            {
                i++;
                m.zonepos = i;
            }

            i = 0;
            foreach (var m in this.enemyMinions)
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
                for (var i = 0; i < 3; i++)
                {
                    this.DiscoverCards.Add(i, discoverCardsList[i + 1]);
                }
            }
        }

        public void updateOwnLastDiedMinion(SimCard cid)
        {
            this.OwnLastDiedMinion = cid;
        }

        private Minion createNewMinion(Handcard hc, int id)
        {
            var m = new Minion
            {
                handcard = new Handcard(hc),
                zonepos = id + 1,
                entitiyID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };


            if (hc.card.Windfury)
            {
                m.windfury = true;
            }

            if (hc.card.Taunt)
            {
                m.taunt = true;
            }

            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = 1;
            }

            if (hc.card.DivineShield)
            {
                m.divineshild = true;
            }

            if (hc.card.Poisonous)
            {
                m.poisonous = true;
            }

            if (hc.card.Lifesteal)
            {
                m.lifesteal = true;
            }

            if (hc.card.Stealth)
            {
                m.stealth = true;
            }

            if (m.name == CardIds.Collectible.Priest.Lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            return m;
        }

        public void printHero()
        {
            this.help.logg("player:");
            this.help.logg(
                $"{this.numMinionsPlayedThisTurn} {this.cardsPlayedThisTurn} {this.ueberladung} {this.lockedMana} {this.ownPlayerController}");

            this.help.logg("ownhero:");
            this.help.logg($"{this.ownHero.CardClass} {this.ownHero.Hp} {this.ownHero.maxHp} {this.ownHero.armor} {this.ownHero.immuneWhileAttacking} {this.ownHero.immune} {this.ownHero.entitiyID} {this.ownHero.Ready} {this.ownHero.numAttacksThisTurn} {this.ownHero.frozen} {this.ownHero.Angr} {this.ownHero.tempAttack} {this.enemyHero.stealth}");
            this.help.logg(
                $"weapon: {this.ownWeapon.Angr} {this.ownWeapon.Durability} {this.ownWeapon.name} {this.ownWeapon.card.CardId} {(this.ownWeapon.poisonous ? 1 : 0)} {(this.ownWeapon.lifesteal ? 1 : 0)}");
            this.help.logg($"ability: {this.ownAbilityisReady} {this.heroAbility.CardId}");
            var secs = "";
            foreach (var sec in this.ownSecretList)
            {
                secs += $"{sec} ";
            }

            this.help.logg($"osecrets: {secs}");
            this.help.logg(
                $"cthunbonus: {this.anzOgOwnCThunAngrBonus} {this.anzOgOwnCThunHpBonus} {this.anzOgOwnCThunTaunt}");
            this.help.logg($"jadegolems: {this.anzOwnJadeGolem} {this.anzEnemyJadeGolem}");
            this.help.logg(
                $"elementals: {this.anzOwnElementalsThisTurn} {this.anzOwnElementalsLastTurn} {this.ownElementalsHaveLifesteal}");
            this.help.logg(Questmanager.Instance.getQuestsString());
            this.help.logg($"advanced: {this.ownCrystalCore} {(this.ownMinionsInDeckCost0 ? 1 : 0)}");
            this.help.logg("enemyhero:");
            this.help.logg(
                $"{this.enemyHero.CardClass} {this.enemyHero.Hp} {this.enemyHero.maxHp} {this.enemyHero.armor} {this.enemyHero.frozen} {this.enemyHero.immune} {this.enemyHero.entitiyID} {this.enemyHero.stealth}");
            this.help.logg(
                $"weapon: {this.enemyWeapon.Angr} {this.enemyWeapon.Durability} {this.enemyWeapon.name} {this.enemyWeapon.card.CardId} {(this.enemyWeapon.poisonous ? 1 : 0)} {(this.enemyWeapon.lifesteal ? 1 : 0)}");
            this.help.logg($"ability: True {this.enemyAbility.CardId}");
            this.help.logg($"fatigue: {this.ownDeckSize} {this.ownHeroFatigue} {this.enemyDeckSize} {this.enemyHeroFatigue}");
        }


        public void printOwnMinions()
        {
            this.help.logg("OwnMinions:");
            foreach (var m in this.ownMinions)
            {
                var mini =
                    $"{m.name} {m.handcard.card.CardId} zp:{m.zonepos} e:{m.entitiyID} A:{m.Angr} H:{m.Hp} mH:{m.maxHp} rdy:{m.Ready} natt:{m.numAttacksThisTurn}";
                if (m.exhausted)
                {
                    mini += " ex";
                }

                if (m.taunt)
                {
                    mini += " tnt";
                }

                if (m.frozen)
                {
                    mini += " frz";
                }

                if (m.silenced)
                {
                    mini += " silenced";
                }

                if (m.divineshild)
                {
                    mini += " divshield";
                }

                if (m.playedThisTurn)
                {
                    mini += " ptt";
                }

                if (m.windfury)
                {
                    mini += " wndfr";
                }

                if (m.stealth)
                {
                    mini += " stlth";
                }

                if (m.poisonous)
                {
                    mini += " poi";
                }

                if (m.lifesteal)
                {
                    mini += " lfst";
                }

                if (m.immune)
                {
                    mini += " imm";
                }

                if (m.untouchable)
                {
                    mini += " untch";
                }

                if (m.conceal)
                {
                    mini += " cncdl";
                }

                if (m.destroyOnOwnTurnStart)
                {
                    mini += " dstrOwnTrnStrt";
                }

                if (m.destroyOnOwnTurnEnd)
                {
                    mini += " dstrOwnTrnnd";
                }

                if (m.destroyOnEnemyTurnStart)
                {
                    mini += " dstrEnmTrnStrt";
                }

                if (m.destroyOnEnemyTurnEnd)
                {
                    mini += " dstrEnmTrnnd";
                }

                if (m.shadowmadnessed)
                {
                    mini += " shdwmdnssd";
                }

                if (m.cantLowerHPbelowONE)
                {
                    mini += " cantLowerHpBelowOne";
                }

                if (m.cantBeTargetedBySpellsOrHeroPowers)
                {
                    mini += " cbtBySpells";
                }

                if (m.charge >= 1)
                {
                    mini += $" chrg({m.charge})";
                }

                if (m.hChoice >= 1)
                {
                    mini += $" hChoice({m.hChoice})";
                }

                if (m.AdjacentAngr >= 1)
                {
                    mini += $" adjaattk({m.AdjacentAngr})";
                }

                if (m.tempAttack != 0)
                {
                    mini += $" tmpattck({m.tempAttack})";
                }

                if (m.spellpower != 0)
                {
                    mini += $" spllpwr({m.spellpower})";
                }

                if (m.ancestralspirit >= 1)
                {
                    mini += $" ancstrl({m.ancestralspirit})";
                }

                if (m.desperatestand >= 1)
                {
                    mini += $" despStand({m.desperatestand})";
                }

                if (m.ownBlessingOfWisdom >= 1)
                {
                    mini += $" ownBlssng({m.ownBlessingOfWisdom})";
                }

                if (m.enemyBlessingOfWisdom >= 1)
                {
                    mini += $" enemyBlssng({m.enemyBlessingOfWisdom})";
                }

                if (m.ownPowerWordGlory >= 1)
                {
                    mini += $" ownGlory({m.ownPowerWordGlory})";
                }

                if (m.enemyPowerWordGlory >= 1)
                {
                    mini += $" enemyGlory({m.enemyPowerWordGlory})";
                }

                if (m.souloftheforest >= 1)
                {
                    mini += $" souloffrst({m.souloftheforest})";
                }

                if (m.stegodon >= 1)
                {
                    mini += $" stegodon({m.stegodon})";
                }

                if (m.livingspores >= 1)
                {
                    mini += $" lspores({m.livingspores})";
                }

                if (m.explorershat >= 1)
                {
                    mini += $" explHat({m.explorershat})";
                }

                if (m.returnToHand >= 1)
                {
                    mini += $" retHand({m.returnToHand})";
                }

                if (m.infest >= 1)
                {
                    mini += $" infest({m.infest})";
                }

                if (m.deathrattle2 != null)
                {
                    mini += $" dethrl({m.deathrattle2.CardId})";
                }

                if (m.name == CardIds.Collectible.Neutral.MoatLurker && this.LurkersDB.ContainsKey(m.entitiyID))
                {
                    mini += $" respawn:{this.LurkersDB[m.entitiyID].IDEnum}:{this.LurkersDB[m.entitiyID].own}";
                }

                this.help.logg(mini);
            }
        }

        public void printEnemyMinions()
        {
            this.help.logg("EnemyMinions:");
            foreach (var m in this.enemyMinions)
            {
                var mini =
                    $"{m.name} {m.handcard.card.CardId} zp:{m.zonepos} e:{m.entitiyID} A:{m.Angr} H:{m.Hp} mH:{m.maxHp} rdy:{m.Ready}"; // +" natt:" + m.numAttacksThisTurn;
                if (m.exhausted)
                {
                    mini += " ex";
                }

                if (m.taunt)
                {
                    mini += " tnt";
                }

                if (m.frozen)
                {
                    mini += " frz";
                }

                if (m.silenced)
                {
                    mini += " silenced";
                }

                if (m.divineshild)
                {
                    mini += " divshield";
                }

                if (m.playedThisTurn)
                {
                    mini += " ptt";
                }

                if (m.windfury)
                {
                    mini += " wndfr";
                }

                if (m.stealth)
                {
                    mini += " stlth";
                }

                if (m.poisonous)
                {
                    mini += " poi";
                }

                if (m.lifesteal)
                {
                    mini += " lfst";
                }

                if (m.immune)
                {
                    mini += " imm";
                }

                if (m.untouchable)
                {
                    mini += " untch";
                }

                if (m.conceal)
                {
                    mini += " cncdl";
                }

                if (m.destroyOnOwnTurnStart)
                {
                    mini += " dstrOwnTrnStrt";
                }

                if (m.destroyOnOwnTurnEnd)
                {
                    mini += " dstrOwnTrnnd";
                }

                if (m.destroyOnEnemyTurnStart)
                {
                    mini += " dstrEnmTrnStrt";
                }

                if (m.destroyOnEnemyTurnEnd)
                {
                    mini += " dstrEnmTrnnd";
                }

                if (m.shadowmadnessed)
                {
                    mini += " shdwmdnssd";
                }

                if (m.cantLowerHPbelowONE)
                {
                    mini += " cantLowerHpBelowOne";
                }

                if (m.cantBeTargetedBySpellsOrHeroPowers)
                {
                    mini += " cbtBySpells";
                }

                if (m.charge >= 1)
                {
                    mini += $" chrg({m.charge})";
                }

                if (m.hChoice >= 1)
                {
                    mini += $" hChoice({m.hChoice})";
                }

                if (m.AdjacentAngr >= 1)
                {
                    mini += $" adjaattk({m.AdjacentAngr})";
                }

                if (m.tempAttack != 0)
                {
                    mini += $" tmpattck({m.tempAttack})";
                }

                if (m.spellpower != 0)
                {
                    mini += $" spllpwr({m.spellpower})";
                }

                if (m.ancestralspirit >= 1)
                {
                    mini += $" ancstrl({m.ancestralspirit})";
                }

                if (m.desperatestand >= 1)
                {
                    mini += $" despStand({m.desperatestand})";
                }

                if (m.ownBlessingOfWisdom >= 1)
                {
                    mini += $" ownBlssng({m.ownBlessingOfWisdom})";
                }

                if (m.enemyBlessingOfWisdom >= 1)
                {
                    mini += $" enemyBlssng({m.enemyBlessingOfWisdom})";
                }

                if (m.ownPowerWordGlory >= 1)
                {
                    mini += $" ownGlory({m.ownPowerWordGlory})";
                }

                if (m.enemyPowerWordGlory >= 1)
                {
                    mini += $" enemyGlory({m.enemyPowerWordGlory})";
                }

                if (m.souloftheforest >= 1)
                {
                    mini += $" souloffrst({m.souloftheforest})";
                }

                if (m.stegodon >= 1)
                {
                    mini += $" stegodon({m.stegodon})";
                }

                if (m.livingspores >= 1)
                {
                    mini += $" lspores({m.livingspores})";
                }

                if (m.explorershat >= 1)
                {
                    mini += $" explHat({m.explorershat})";
                }

                if (m.returnToHand >= 1)
                {
                    mini += $" retHand({m.returnToHand})";
                }

                if (m.infest >= 1)
                {
                    mini += $" infest({m.infest})";
                }

                if (m.deathrattle2 != null)
                {
                    mini += $" dethrl({m.deathrattle2.CardId})";
                }

                if (m.name == CardIds.Collectible.Neutral.MoatLurker && this.LurkersDB.ContainsKey(m.entitiyID))
                {
                    mini += $" respawn:{this.LurkersDB[m.entitiyID].IDEnum}:{this.LurkersDB[m.entitiyID].own}";
                }

                this.help.logg(mini);
            }
        }

        public void printOwnDeck()
        {
            var od = "od: ";
            foreach (var e in this.turnDeck)
            {
                od += $"{e.Key},{e.Value};";
            }

            Helpfunctions.Instance.logg(od);
        }
    }
}