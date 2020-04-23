using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Triton.Game;
using Triton.Game.Mapping;

namespace HREngine.Bots
{
    public class Silverfish
    {
        public string versionnumber = "117.178";
        private bool singleLog = false;
        private string botbehave = "noname";
        private bool needSleep = false;

        public Playfield lastpf;
        private Settings sttngs = Settings.Instance;

        private List<Minion> ownMinions = new List<Minion>();
        private List<Minion> enemyMinions = new List<Minion>();
        private List<Handcard> handCards = new List<Handcard>();
        private int ownPlayerController = 0;
        private List<string> ownSecretList = new List<string>();
        private Dictionary<int, CardClass> enemySecretList = new Dictionary<int, CardClass>();
        private Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();
        public Dictionary<string, Behavior> BehaviorDB = new Dictionary<string, Behavior>();
        public Dictionary<string, string> BehaviorPath = new Dictionary<string, string>();
        private List<HSCard> ETallcards = new List<HSCard>();
        private Dictionary<string, int> startDeck = new Dictionary<string, int>();
        private Dictionary<SimCard, int> turnDeck = new Dictionary<SimCard, int>();
        private Dictionary<int, extraCard> extraDeck = new Dictionary<int, extraCard>();
        private bool noDuplicates = false;

        private int currentMana = 0;
        private int ownMaxMana = 0;
        private int numOptionPlayedThisTurn = 0;
        private int numMinionsPlayedThisTurn = 0;
        private int cardsPlayedThisTurn = 0;
        private int ueberladung = 0;
        private int lockedMana = 0;

        private int enemyMaxMana = 0;

        private SimCard heroAbility = new SimCard();
        private int ownHeroPowerCost = 2;
        private bool ownAbilityisReady = false;
        private SimCard enemyAbility = new SimCard();
        private int enemyHeroPowerCost = 2;

        private Weapon ownWeapon;
        private Weapon enemyWeapon;

        private int anzcards = 0;
        private int enemyAnzCards = 0;

        private int ownHeroFatigue = 0;
        private int enemyHeroFatigue = 0;
        private int ownDecksize = 0;
        private int enemyDecksize = 0;

        private Minion ownHero;
        private Minion enemyHero;

        private int gTurn = 0;
        private int gTurnStep = 0;
        private int anzOgOwnCThunHpBonus = 0;
        private int anzOgOwnCThunAngrBonus = 0;
        private int anzOgOwnCThunTaunt = 0;
        private int ownCrystalCore = 0;
        private bool ownMinionsCost0 = false;

        private class extraCard
        {
            public string id;
            public bool isindeck;

            public extraCard(string s, bool b)
            {
                this.id = s;
                this.isindeck = b;
            }
            public void setId(string s)
            {
                this.id = s;
            }
            public void setisindeck(bool b)
            {
                this.isindeck = b;
            }
        }

        private static Silverfish instance;

        public static Silverfish Instance => instance ?? (instance = new Silverfish());

        private Silverfish()
        {
            this.singleLog = Settings.Instance.writeToSingleFile;
            Helpfunctions.Instance.ErrorLog("开始启动...");
            var p =
                $".{System.IO.Path.DirectorySeparatorChar}Routines{System.IO.Path.DirectorySeparatorChar}DefaultRoutine{System.IO.Path.DirectorySeparatorChar}Silverfish{System.IO.Path.DirectorySeparatorChar}";
            var path = $"{p}UltimateLogs{Path.DirectorySeparatorChar}";
            Directory.CreateDirectory(path);
            this.sttngs.setFilePath($"{p}Data{Path.DirectorySeparatorChar}");

            if (!this.singleLog)
            {
                this.sttngs.setLoggPath(path);
            }
            else
            {
                this.sttngs.setLoggPath(p);
                this.sttngs.setLoggFile("UILogg.txt");
                Helpfunctions.Instance.createNewLoggfile();
            }
            this.setBehavior();
        }

        private bool setBehavior()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Behavior)).ToArray();
            foreach (var t in types)
            {
                var s = t.Name;
                if (s == "BehaviorMana")
                {
                    continue;
                }

                if (s.Length > 8 && s.Substring(0, 8) == "Behavior")
                {
                    var b = (Behavior)Activator.CreateInstance(t);
                    this.BehaviorDB.Add(b.BehaviorName(), b);
                }
            }

            var p = Path.Combine("Routines", "DefaultRoutine", "Silverfish", "behavior");
            var files = Directory.GetFiles(p, "Behavior*.cs", SearchOption.AllDirectories);
            var bCount = 0;
            foreach (var file in files)
            {
                bCount++;
                var bPath = Path.GetDirectoryName(file);
                var fullPath = Path.GetFullPath(file);
                var bNane = Path.GetFileNameWithoutExtension(file).Remove(0, 8);
                if (this.BehaviorDB.ContainsKey(bNane))
                {
                    if (!this.BehaviorPath.ContainsKey(bNane))
                    {
                        this.BehaviorPath.Add(bNane, bPath);
                    }
                }
            }

            if (this.BehaviorDB.Count != this.BehaviorPath.Count || this.BehaviorDB.Count != bCount)
            {
                Helpfunctions.Instance.ErrorLog(
                    $"Behavior: registered - {this.BehaviorDB.Count}, folders - {bCount}, have a path - {this.BehaviorPath.Count}. These values should be the same. Maybe you have some extra files in the 'custom_behavior' folder.");
            }

            if (this.BehaviorDB.ContainsKey("控场模式"))
            {
                Ai.Instance.botBase = this.BehaviorDB["控场模式"];
                return true;
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("没有找到战场策略!");
                Helpfunctions.Instance.ErrorLog("请把战场策略放到指定的文件中.");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                return false;
            }
        }
        public Behavior getBehaviorByName(string bName)
        {
            if (this.BehaviorDB.ContainsKey(bName))
            {
                this.sttngs.setSettings(bName);
                ComboBreaker.Instance.readCombos(bName);
                RulesEngine.Instance.readRules(bName);
                return this.BehaviorDB[bName];
            }
            else
            {
                if (this.BehaviorDB.ContainsKey("控场模式"))
                {
                    return this.BehaviorDB["控场模式"];
                }
                else
                {
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                    Helpfunctions.Instance.ErrorLog("没有找到战场策略!");
                    Helpfunctions.Instance.ErrorLog("请把战场策略放到指定的文件中.");
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                }
            }
            return null;
        }


        public void setnewLoggFile()
        {
            this.gTurn = 0;
            this.gTurnStep = 0;
            this.anzOgOwnCThunHpBonus = 0;
            this.anzOgOwnCThunAngrBonus = 0;
            this.anzOgOwnCThunTaunt = 0;
            this.ownCrystalCore = 0;
            this.ownMinionsCost0 = false;
            Questmanager.Instance.Reset();
            if (!this.singleLog)
            {
                this.sttngs.setLoggFile($"UILogg{DateTime.Now:_yyyy-MM-dd_HH-mm-ss}.txt");
                Helpfunctions.Instance.createNewLoggfile();
                Helpfunctions.Instance.ErrorLog("#######################################################");
                Helpfunctions.Instance.ErrorLog($"对局日志保持在: {this.sttngs.logpath}{this.sttngs.logfile}");
                Helpfunctions.Instance.ErrorLog("#######################################################");
            }
            else
            {
                this.sttngs.setLoggFile("UILogg.txt");
            }

            this.startDeck.Clear();
            this.extraDeck.Clear();
            var DeckId = Triton.Bot.Logic.Bots.DefaultBot.DefaultBotSettings.Instance.LastDeckId;
            foreach (var deck in Triton.Bot.Settings.MainSettings.Instance.CustomDecks)
            {
                if (deck.DeckId == DeckId)
                {
                    foreach (var s in deck.CardIds)
                    {
                        if (this.startDeck.ContainsKey(s))
                        {
                            this.startDeck[s]++;
                        }
                        else
                        {
                            this.startDeck.Add(s, 1);
                        }
                    }
                    break;
                }
            }
        }

        public bool updateEverything(Behavior botbase, int numcal, out bool sleepRetry)
        {
            this.needSleep = false;
            this.updateBehaveString(botbase);
            this.ownPlayerController = TritonHs.OurHero.ControllerId;

            Hrtprozis.Instance.clearAllRecalc();
            Handmanager.Instance.clearAllRecalc();

            this.getHerostuff();
            this.getMinions();
            this.getHandcards();
            this.getDecks();


            Hrtprozis.Instance.updateTurnDeck(this.turnDeck, this.noDuplicates);
            Hrtprozis.Instance.setOwnPlayer(this.ownPlayerController);
            Handmanager.Instance.setOwnPlayer(this.ownPlayerController);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + this.ownHero.numAttacksThisTurn;
            foreach (var m in this.ownMinions)
            {
                if (m.Hp >= 1)
                {
                    this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
                }
            }

            var list = TritonHs.GetCards(CardZone.Graveyard, true);
            foreach (var gi in Probabilitymaker.Instance.turngraveyard)
            {
                if (gi.own)
                {
                    foreach (var entiti in list)
                    {
                        if (gi.entity == entiti.EntityId)
                        {
                            this.numOptionPlayedThisTurn += entiti.NumAttackThisTurn;
                            break;
                        }
                    }
                }
            }

            Hrtprozis.Instance.updatePlayer(this.ownMaxMana, this.currentMana, this.cardsPlayedThisTurn,
                this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.ueberladung, this.lockedMana, TritonHs.OurHero.EntityId,
                TritonHs.EnemyHero.EntityId);
            Hrtprozis.Instance.updateSecretStuff(this.ownSecretList, this.enemySecretList.Count);

            Hrtprozis.Instance.updateHero(this.ownWeapon, this.ownHero.CardClass, this.heroAbility, this.ownAbilityisReady, this.ownHeroPowerCost, this.ownHero);
            Hrtprozis.Instance.updateHero(this.enemyWeapon, this.enemyHero.CardClass, this.enemyAbility, false, this.enemyHeroPowerCost, this.enemyHero, this.enemyMaxMana);

            Questmanager.Instance.updatePlayedMobs(this.gTurnStep);
            Hrtprozis.Instance.updateMinions(this.ownMinions, this.enemyMinions);
            Hrtprozis.Instance.updateLurkersDB(this.LurkersDB);
            Handmanager.Instance.setHandcards(this.handCards, this.anzcards, this.enemyAnzCards);
            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownHeroFatigue, this.enemyDecksize, this.enemyHeroFatigue);
            Hrtprozis.Instance.updateJadeGolemsInfo(GameState.Get().GetFriendlySidePlayer().GetTag(GAME_TAG.JADE_GOLEM), GameState.Get().GetOpposingSidePlayer().GetTag(GAME_TAG.JADE_GOLEM));

            Hrtprozis.Instance.updateTurnInfo(this.gTurn, this.gTurnStep);
            this.updateCThunInfobyCThun();
            Hrtprozis.Instance.updateCThunInfo(this.anzOgOwnCThunAngrBonus, this.anzOgOwnCThunHpBonus, this.anzOgOwnCThunTaunt);
            Hrtprozis.Instance.updateCrystalCore(this.ownCrystalCore);
            Hrtprozis.Instance.updateOwnMinionsInDeckCost0(this.ownMinionsCost0);
            Probabilitymaker.Instance.setEnemySecretGuesses(this.enemySecretList);

            sleepRetry = this.needSleep;
            if (sleepRetry && numcal == 0)
            {
                return false;
            }

            if (!Hrtprozis.Instance.setGameRule)
            {
                RulesEngine.Instance.setCardIdRulesGame(this.ownHero.CardClass, this.enemyHero.CardClass);
                Hrtprozis.Instance.setGameRule = true;
            }

            var p = new Playfield
            {
                enemyCardsOut = new Dictionary<SimCard, int>(Probabilitymaker.Instance.enemyCardsOut)
            };

            if (this.lastpf != null)
            {
                if (this.lastpf.isEqualf(p))
                {
                    return false;
                }
                else
                {
                    if (p.gTurnStep > 0 && Ai.Instance.nextMoveGuess.ownMinions.Count == p.ownMinions.Count)
                    {
                        if (Ai.Instance.nextMoveGuess.ownHero.Ready != p.ownHero.Ready && !p.ownHero.Ready)
                        {
                            sleepRetry = true;
                            Helpfunctions.Instance.ErrorLog($"[AI] 英雄的准备状态 = {p.ownHero.Ready}. 再次尝试....");
                            Ai.Instance.nextMoveGuess = new Playfield { mana = -100 };
                            return false;
                        }
                        for (var i = 0; i < p.ownMinions.Count; i++)
                        {
                            if (Ai.Instance.nextMoveGuess.ownMinions[i].Ready != p.ownMinions[i].Ready && !p.ownMinions[i].Ready)
                            {
                                sleepRetry = true;
                                Helpfunctions.Instance.ErrorLog(
                                    $"[AI] 随从的准备状态 = {p.ownMinions[i].Ready} ({p.ownMinions[i].entitiyID} {p.ownMinions[i].handcard.card.CardId} {p.ownMinions[i].name}). 再次尝试....");
                                Ai.Instance.nextMoveGuess = new Playfield { mana = -100 };
                                return false;
                            }
                        }
                    }
                }

                Probabilitymaker.Instance.updateSecretList(p, this.lastpf);
                this.lastpf = p;
            }
            else
            {
                this.lastpf = p;
            }

            p = new Playfield();

            Helpfunctions.Instance.ErrorLog($"AI计算中，请稍候... {DateTime.Now:HH:mm:ss.ffff}");


            using (TritonHs.Memory.ReleaseFrame(true))
            {
                this.printstuff();
                Ai.Instance.dosomethingclever(botbase);
            }

            Helpfunctions.Instance.ErrorLog($"计算完成! {DateTime.Now:HH:mm:ss.ffff}");
            if (this.sttngs.printRules > 0)
            {
                var rulesStr = Ai.Instance.bestplay.rulesUsed.Split('@');
                if (rulesStr.Count() > 0 && rulesStr[0] != "")
                {
                    Helpfunctions.Instance.ErrorLog($"规则权重 {Ai.Instance.bestplay.ruleWeight * -1}");
                    foreach (var rs in rulesStr)
                    {
                        if (rs == "")
                        {
                            continue;
                        }

                        Helpfunctions.Instance.ErrorLog($"规则: {rs}");
                    }
                }
            }
            return true;
        }




        private void getHerostuff()
        {
            var allcards = TritonHs.GetAllCards();

            var ownHeroCard = TritonHs.OurHero;
            var enemHeroCard = TritonHs.EnemyHero;
            var ownheroentity = TritonHs.OurHero.EntityId;
            var enemyheroentity = TritonHs.EnemyHero.EntityId;
            this.ownHero = new Minion();
            this.enemyHero = new Minion();

            foreach (var ent in allcards)
            {
                if (ent.IsHero == true)
                {
                    if (ent.ControllerId == 1 && this.ownHero.CardClass == CardClass.INVALID)
                    {
                        this.ownHero.CardClass = (CardClass)ent.Class;
                    }
                    if (ent.ControllerId == 2 && this.enemyHero.CardClass == CardClass.INVALID)
                    {
                        this.enemyHero.CardClass = (CardClass)ent.Class;
                    }
                    if (ent.EntityId == enemyheroentity)
                    {
                        enemHeroCard = ent;
                    }

                    if (ent.EntityId == ownheroentity)
                    {
                        ownHeroCard = ent;
                    }
                }
            }



            this.currentMana = TritonHs.CurrentMana;
            this.ownMaxMana = TritonHs.Resources;
            this.enemyMaxMana = this.ownMaxMana;


            this.ownSecretList.Clear();
            this.enemySecretList.Clear();
            foreach (var ent in allcards)
            {
                if (ent.IsSecret && ent.ControllerId != this.ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 7)
                {
                    this.enemySecretList.Add(ent.EntityId, (CardClass)ent.Class);
                }
                if (ent.IsSecret && ent.ControllerId == this.ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 7)
                {
                    this.ownSecretList.Add(ent.Id);
                }
            }

            var ownSecretZoneCards = GameState.Get().GetFriendlySidePlayer().GetSecretZone().GetCards();
            foreach (var card in ownSecretZoneCards)
            {
                var entity = card.GetEntity();
                if (entity != null && entity.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET)
                {
                    if (entity.m_card != null)
                    {
                        var eId = "";




                        if (entity.IsQuest())
                        {
                            var currentQuestProgress = entity.GetTag(GAME_TAG.QUEST_PROGRESS);
                            var questProgressTotal = entity.GetTag(GAME_TAG.QUEST_PROGRESS_TOTAL);

                            var entityDef = DefLoader.Get().GetEntityDef(entity.GetTag(GAME_TAG.QUEST_CONTRIBUTOR));
                            if (entityDef != null)
                            {
                                var nme = entityDef.GetName();
                            }

                            Questmanager.Instance.updateQuestStuff(eId, currentQuestProgress, questProgressTotal, true);
                        }
                    }
                }
            }

            var enemySecretZoneCards = GameState.Get().GetOpposingSidePlayer().GetSecretZone().GetCards();
            foreach (var card in enemySecretZoneCards)
            {
                var entity = card.GetEntity();
                if (entity != null && entity.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET)
                {
                    if (entity.m_card != null)
                    {
                        var eId = "";




                        if (entity.IsQuest())
                        {
                            var currentQuestProgress = entity.GetTag(GAME_TAG.QUEST_PROGRESS);
                            var questProgressTotal = entity.GetTag(GAME_TAG.QUEST_PROGRESS_TOTAL);
                            Questmanager.Instance.updateQuestStuff(eId, currentQuestProgress, questProgressTotal, false);
                        }
                    }
                }
            }

            this.numMinionsPlayedThisTurn = TritonHs.NumMinionsPlayedThisTurn;
            this.cardsPlayedThisTurn = TritonHs.NumCardsPlayedThisTurn;
            this.ueberladung = TritonHs.OverloadOwed;
            this.lockedMana = TritonHs.OverloadLocked;

            this.ownHeroFatigue = ownHeroCard.GetTag(GAME_TAG.FATIGUE);
            this.enemyHeroFatigue = enemHeroCard.GetTag(GAME_TAG.FATIGUE);

            this.ownDecksize = 0;
            this.enemyDecksize = 0;

            foreach (var ent in allcards)
            {
                if (ent.ControllerId == this.ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 2)
                {
                    this.ownDecksize++;
                }

                if (ent.ControllerId != this.ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 2)
                {
                    this.enemyDecksize++;
                }
            }

            this.ownHero.CardClass = SimCard.FromName(TritonHs.OurHero.Id).CardDef.Class;

            this.ownHero.Angr = ownHeroCard.GetTag(GAME_TAG.ATK);
            this.ownHero.Hp = ownHeroCard.GetTag(GAME_TAG.HEALTH) - ownHeroCard.GetTag(GAME_TAG.DAMAGE);
            this.ownHero.armor = ownHeroCard.GetTag(GAME_TAG.ARMOR);
            this.ownHero.frozen = (ownHeroCard.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;
            this.ownHero.stealth = (ownHeroCard.GetTag(GAME_TAG.STEALTH) == 0) ? false : true;
            this.ownHero.numAttacksThisTurn = ownHeroCard.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);
            this.ownHero.windfury = (ownHeroCard.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;
            this.ownHero.immune = (ownHeroCard.GetTag(GAME_TAG.IMMUNE) == 0) ? false : true;
            if (!this.ownHero.immune)
            {
                this.ownHero.immune = (ownHeroCard.GetTag(GAME_TAG.IMMUNE_WHILE_ATTACKING) == 0) ? false : true; //turn immune
            }

            this.ownWeapon = new Weapon();
            if (TritonHs.DoWeHaveWeapon)
            {
                var weapon = TritonHs.OurWeaponCard;

                this.ownWeapon.equip(((weapon.Id)));
                this.ownWeapon.Angr = weapon.GetTag(GAME_TAG.ATK);
                this.ownWeapon.Durability = weapon.GetTag(GAME_TAG.DURABILITY) - weapon.GetTag(GAME_TAG.DAMAGE);
                this.ownWeapon.poisonous = (weapon.GetTag(GAME_TAG.POISONOUS) == 1) ? true : false;
                this.ownWeapon.lifesteal = (weapon.GetTag(GAME_TAG.LIFESTEAL) == 1) ? true : false;
                if (!this.ownHero.windfury)
                {
                    this.ownHero.windfury = this.ownWeapon.windfury;
                }
            }

            this.enemyHero.CardClass = SimCard.FromName(TritonHs.EnemyHero.Id).Class;

            this.enemyHero.Angr = enemHeroCard.GetTag(GAME_TAG.ATK);
            this.enemyHero.Hp = enemHeroCard.GetTag(GAME_TAG.HEALTH) - enemHeroCard.GetTag(GAME_TAG.DAMAGE);
            this.enemyHero.armor = enemHeroCard.GetTag(GAME_TAG.ARMOR);
            this.enemyHero.frozen = (enemHeroCard.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;
            this.enemyHero.stealth = (enemHeroCard.GetTag(GAME_TAG.STEALTH) == 0) ? false : true;
            this.enemyHero.windfury = (enemHeroCard.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;
            this.enemyHero.immune = (enemHeroCard.GetTag(GAME_TAG.IMMUNE) == 0) ? false : true; //don't use turn immune

            this.enemyWeapon = new Weapon();
            if (TritonHs.DoesEnemyHasWeapon)
            {
                var weapon = TritonHs.EnemyWeaponCard;

                this.enemyWeapon.equip(((weapon.Id)));
                this.enemyWeapon.Angr = weapon.GetTag(GAME_TAG.ATK);
                this.enemyWeapon.Durability = weapon.GetTag(GAME_TAG.DURABILITY) - weapon.GetTag(GAME_TAG.DAMAGE);
                this.enemyWeapon.poisonous = (weapon.GetTag(GAME_TAG.POISONOUS) == 1) ? true : false;
                this.enemyWeapon.lifesteal = (weapon.GetTag(GAME_TAG.LIFESTEAL) == 1) ? true : false;
                if (!this.enemyHero.windfury)
                {
                    this.enemyHero.windfury = this.enemyWeapon.windfury;
                }
            }

            this.heroAbility =
                ((TritonHs.OurHeroPowerCard.Id));
            this.ownAbilityisReady = (TritonHs.OurHeroPowerCard.GetTag(GAME_TAG.EXHAUSTED) == 0) ? true : false;
            this.enemyAbility =
                ((TritonHs.EnemyHeroPowerCard.Id));
            var ownHeroAbilityEntity = TritonHs.OurHeroPowerCard.EntityId;
            var enemyHeroAbilityEntity = TritonHs.EnemyHeroPowerCard.EntityId;

            var needBreak = 0;
            foreach (var ent in allcards)
            {
                if (ent.EntityId == ownHeroAbilityEntity)
                {
                    this.ownHeroPowerCost = ent.Cost;
                    needBreak++;
                }
                else if (ent.EntityId == enemyHeroAbilityEntity)
                {
                    this.enemyHeroPowerCost = ent.Cost;
                    needBreak++;
                }
                if (needBreak > 1)
                {
                    break;
                }
            }

            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = ownHeroCard.GetTag(GAME_TAG.HEALTH);
            this.enemyHero.maxHp = enemHeroCard.GetTag(GAME_TAG.HEALTH);
            this.ownHero.entitiyID = ownHeroCard.EntityId;
            this.enemyHero.entitiyID = enemHeroCard.EntityId;

            this.ownHero.Ready = ownHeroCard.CanBeUsed;
            this.enemyHero.Ready = false;

            var miniEnchlist = new List<miniEnch>();
            foreach (var ent in allcards)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == this.ownHero.entitiyID && ent.GetTag(GAME_TAG.ZONE) == 1)
                {
                    SimCard id = (ent.Id);
                    var controler = ent.GetTag(GAME_TAG.CONTROLLER);
                    var creator = ent.GetTag(GAME_TAG.CREATOR);
                    var copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                    miniEnchlist.Add(new miniEnch(id, creator, controler, copyDeathrattle));
                }
            }

            this.ownHero.loadEnchantments(miniEnchlist, ownHeroCard.GetTag(GAME_TAG.CONTROLLER));

            miniEnchlist.Clear();

            foreach (var ent in allcards)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == this.enemyHero.entitiyID && ent.GetTag(GAME_TAG.ZONE) == 1)

                {
                    SimCard id = (ent.Id);
                    var controler = ent.GetTag(GAME_TAG.CONTROLLER);
                    var creator = ent.GetTag(GAME_TAG.CREATOR);
                    var copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                    miniEnchlist.Add(new miniEnch(id, creator, controler, copyDeathrattle));
                }
            }

            this.enemyHero.loadEnchantments(miniEnchlist, enemHeroCard.GetTag(GAME_TAG.CONTROLLER));

            if (this.ownHero.Angr < this.ownWeapon.Angr)
            {
                this.ownHero.Angr = this.ownWeapon.Angr;
            }

            if (this.enemyHero.Angr < this.enemyWeapon.Angr)
            {
                this.enemyHero.Angr = this.enemyWeapon.Angr;
            }
        }



        private void getMinions()
        {
            var tmp = Triton.Game.Mapping.GameState.Get().GetTurn();
            if (this.gTurn == tmp)
            {
                this.gTurnStep++;
            }
            else
            {
                this.gTurnStep = 0;
            }

            this.gTurn = tmp;

            var list = TritonHs.GetCards(CardZone.Battlefield, true);
            list.AddRange(TritonHs.GetCards(CardZone.Battlefield, false));

            var enchantments = new List<HSCard>();
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            this.LurkersDB.Clear();
            var allcards = TritonHs.GetAllCards();

            foreach (var entiti in list)
            {
                var zp = entiti.GetTag(GAME_TAG.ZONE_POSITION);

                if (entiti.IsMinion && zp >= 1)
                {

                    var entitiy = entiti;

                    foreach (var ent in allcards)
                    {
                        if (ent.EntityId == entiti.EntityId)
                        {
                            entitiy = ent;
                            break;
                        }
                    }


                    SimCard c = ((entitiy.Id));
                    var m = new Minion
                    {
                        name = c.CardId
                    };
                    m.handcard.card = c;

                    m.Angr = entitiy.GetTag(GAME_TAG.ATK);
                    m.maxHp = entitiy.GetTag(GAME_TAG.HEALTH);
                    m.Hp = entitiy.GetTag(GAME_TAG.HEALTH) - entitiy.GetTag(GAME_TAG.DAMAGE);
                    if (m.Hp <= 0)
                    {
                        continue;
                    }

                    m.wounded = false;
                    if (m.maxHp > m.Hp)
                    {
                        m.wounded = true;
                    }

                    var ctarget = entitiy.GetTag(GAME_TAG.CARD_TARGET);
                    if (ctarget > 0)
                    {
                        foreach (var hcard in allcards)
                        {
                            if (hcard.EntityId == ctarget)
                            {
                                this.LurkersDB.Add(entitiy.EntityId, new IDEnumOwner()
                                {
                                    IDEnum = (hcard.Id),
                                    own = (hcard.GetTag(GAME_TAG.CONTROLLER) == this.ownPlayerController) ? true : false
                                });
                                break;
                            }
                        }
                    }

                    m.exhausted = (entitiy.GetTag(GAME_TAG.EXHAUSTED) == 0) ? false : true;

                    m.taunt = (entitiy.GetTag(GAME_TAG.TAUNT) == 0) ? false : true;

                    m.numAttacksThisTurn = entitiy.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);

                    var temp = entitiy.GetTag(GAME_TAG.NUM_TURNS_IN_PLAY);
                    m.playedThisTurn = (temp == 0) ? true : false;

                    m.windfury = (entitiy.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;

                    m.frozen = (entitiy.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;

                    m.divineshild = (entitiy.GetTag(GAME_TAG.DIVINE_SHIELD) == 0) ? false : true;

                    m.stealth = (entitiy.GetTag(GAME_TAG.STEALTH) == 0) ? false : true;

                    m.poisonous = (entitiy.GetTag(GAME_TAG.POISONOUS) == 0) ? false : true;

                    m.lifesteal = (entitiy.GetTag(GAME_TAG.LIFESTEAL) == 0) ? false : true;

                    m.immune = (entitiy.GetTag(GAME_TAG.IMMUNE) == 0) ? false : true;
                    if (!m.immune)
                    {
                        m.immune = (entitiy.GetTag(GAME_TAG.IMMUNE_WHILE_ATTACKING) == 0) ? false : true;
                    }

                    m.untouchable = (entitiy.GetTag(GAME_TAG.UNTOUCHABLE) == 0) ? false : true;

                    m.silenced = (entitiy.GetTag(GAME_TAG.SILENCED) == 0) ? false : true;

                    m.cantAttackHeroes = (entitiy.GetTag(GAME_TAG.CANNOT_ATTACK_HEROES) == 0) ? false : true;

                    m.cantAttack = (entitiy.GetTag(GAME_TAG.CANT_ATTACK) == 0) ? false : true;

                    m.cantBeTargetedBySpellsOrHeroPowers = (entitiy.GetTag(GAME_TAG.CANT_BE_TARGETED_BY_HERO_POWERS) == 0) ? false : true;

                    m.charge = entitiy.HasCharge ? 1 : 0;

                    m.rush = entitiy.HasRush ? 1 : 0;

                    m.zonepos = zp;

                    m.entitiyID = entitiy.EntityId;



                    m.hChoice = entitiy.GetTag(GAME_TAG.HIDDEN_CHOICE);

                    var enchs = new List<miniEnch>();
                    foreach (var ent in allcards)
                    {
                        if (ent.GetTag(GAME_TAG.ATTACHED) == m.entitiyID && ent.GetTag(GAME_TAG.ZONE) == 1)
                        {
                            SimCard id = (ent.Id);
                            var controler = ent.GetTag(GAME_TAG.CONTROLLER);
                            var creator = ent.GetTag(GAME_TAG.CREATOR);
                            var copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                            enchs.Add(new miniEnch(id, creator, controler, copyDeathrattle));
                        }
                    }

                    m.loadEnchantments(enchs, entitiy.GetTag(GAME_TAG.CONTROLLER));
                    if (m.extraParam2 != 0)
                    {
                        var needBreak = false;
                        foreach (var ent in allcards)
                        {
                            if (m.extraParam2 == ent.EntityId)
                            {
                                var copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                                switch (ent.Id)
                                {
                                    case "LOE_019":
                                        foreach (var ent2 in allcards)
                                        {
                                            if (copyDeathrattle == ent2.EntityId)
                                            {
                                                if (ent2.Id == "LOE_019")
                                                {
                                                    copyDeathrattle = ent2.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                                                    goto case "LOE_019";
                                                }
                                                m.deathrattle2 = ((ent2.Id));
                                                needBreak = true;
                                                break;
                                            }
                                        }
                                        break;
                                    default:
                                        m.deathrattle2 = ((ent.Id));
                                        needBreak = true;
                                        break;
                                }
                            }
                            if (needBreak)
                            {
                                break;
                            }
                        }
                    }

                    m.Ready = entitiy.CanBeUsed;
                    if (m.rush > 0 && m.playedThisTurn && m.charge == 0 && (m.numAttacksThisTurn == 0 || (m.windfury && m.numAttacksThisTurn == 1)))
                    {
                        m.Ready = true;
                        m.cantAttackHeroes = true;
                    }

                    if (m.charge > 0 && m.playedThisTurn && !m.Ready && m.numAttacksThisTurn == 0)
                    {
                        this.needSleep = true;
                        Helpfunctions.Instance.ErrorLog("[AI] 冲锋的随从还没有准备好");
                    }

                    if (entitiy.GetTag(GAME_TAG.CONTROLLER) == this.ownPlayerController)
                    {
                        m.own = true;
                        m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(this.ownHero.CardClass, c.Race);
                        this.ownMinions.Add(m);
                    }
                    else
                    {
                        m.own = false;
                        m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(this.enemyHero.CardClass, c.Race);
                        this.enemyMinions.Add(m);
                    }
                }
            }
        }

        private void getHandcards()
        {
            this.handCards.Clear();
            this.anzcards = 0;
            this.enemyAnzCards = 0;
            var list = TritonHs.GetCards(CardZone.Hand);



            var wereElementalsLastTurn = 0;
            foreach (var entitiy in list)
            {
                if (entitiy.ZonePosition >= 1)
                {
                    SimCard c = ((entitiy.Id));



                    var hc = new Handcard
                    {
                        card = c,
                        position = entitiy.ZonePosition,
                        entity = entitiy.EntityId,
                        manacost = entitiy.Cost,
                        elemPoweredUp = entitiy.GetTag(GAME_TAG.ELEMENTAL_POWERED_UP)
                    };
                    if (hc.elemPoweredUp > 0)
                    {
                        wereElementalsLastTurn = 1;
                    }

                    hc.addattack = entitiy.Attack - entitiy.DefATK;
                    if (entitiy.IsWeapon)
                    {
                        hc.addHp = entitiy.Durability - entitiy.DefDurability;
                    }
                    else
                    {
                        hc.addHp = entitiy.Health - entitiy.DefHealth;
                    }

                    this.handCards.Add(hc);
                    this.anzcards++;
                }
            }
            Hrtprozis.Instance.updateElementals(0, wereElementalsLastTurn, 0); //TODO

            var allcards = TritonHs.GetAllCards();
            this.enemyAnzCards = 0;
            foreach (var hs in allcards)
            {
                if (hs.GetTag(GAME_TAG.ZONE) == 3 && hs.ControllerId != this.ownPlayerController &&
                    hs.GetTag(GAME_TAG.ZONE_POSITION) >= 1)
                {
                    this.enemyAnzCards++;
                }
            }
        }

        private void getDecks()
        {
            var tmpDeck = new Dictionary<string, int>(this.startDeck);
            var graveYard = new List<GraveYardItem>();
            var og = new Dictionary<SimCard, int>();
            var eg = new Dictionary<SimCard, int>();
            var owncontroler = TritonHs.OurHero.GetTag(GAME_TAG.CONTROLLER);
            var enemycontroler = TritonHs.EnemyHero.GetTag(GAME_TAG.CONTROLLER);
            this.turnDeck.Clear();
            this.noDuplicates = false;

            var allcards = TritonHs.GetAllCards();

            var allcardscount = allcards.Count;
            for (var i = 0; i < allcardscount; i++)
            {
                var entity = allcards[i];
                if (entity.Id == null || entity.Id == "")
                {
                    continue;
                }

                if ((entity.Id) == CardIds.NonCollectible.Druid.JungleGiants_BarnabusTheStomperToken)
                {
                    this.ownMinionsCost0 = true;
                }

                if (entity.GetZone() == Triton.Game.Mapping.TAG_ZONE.GRAVEYARD)
                {
                    SimCard cide = (entity.Id);
                    var gyi = new GraveYardItem(cide, entity.EntityId, entity.GetTag(GAME_TAG.CONTROLLER) == owncontroler);
                    graveYard.Add(gyi);

                    if (entity.GetTag(GAME_TAG.CONTROLLER) == owncontroler)
                    {
                        if (og.ContainsKey(cide))
                        {
                            og[cide]++;
                        }
                        else
                        {
                            og.Add(cide, 1);
                        }
                    }
                    else if (entity.GetTag(GAME_TAG.CONTROLLER) == enemycontroler)
                    {
                        if (eg.ContainsKey(cide))
                        {
                            eg[cide]++;
                        }
                        else
                        {
                            eg.Add(cide, 1);
                        }
                    }
                    if (cide == CardIds.NonCollectible.Rogue.TheCavernsBelow_CrystalCoreTokenUNGORO)
                    {
                        this.ownCrystalCore = 5;
                    }
                }

                var entityId = entity.Id;
                var entZone = entity.GetZone();
                if (i < 30)
                {
                    if (entityId != "")
                    {
                        if (entZone == Triton.Game.Mapping.TAG_ZONE.DECK)
                        {
                            continue;
                        }

                        if (tmpDeck.ContainsKey(entityId))
                        {
                            tmpDeck[entityId]--;
                        }
                    }
                }
                else if (i >= 60 && entity.ControllerId == owncontroler)
                {
                    if (this.extraDeck.ContainsKey(i))
                    {
                        if (entityId != "" && entityId != this.extraDeck[i].id)
                        {
                            this.extraDeck[i].setId(entityId);
                        }

                        if ((entZone == Triton.Game.Mapping.TAG_ZONE.DECK) != this.extraDeck[i].isindeck)
                        {
                            this.extraDeck[i].setisindeck(entZone == Triton.Game.Mapping.TAG_ZONE.DECK);
                        }
                    }
                    else if (entZone == Triton.Game.Mapping.TAG_ZONE.DECK)
                    {
                        this.extraDeck.Add(i, new extraCard(entityId, true));
                    }
                }
            }

            var a = Ai.Instance.bestmove;
            foreach (var c in this.extraDeck)
            {
                if (c.Value.isindeck == false)
                {
                    continue;
                }

                SimCard ce;
                var entityId = c.Value.id;
                if (entityId == "")
                {
                    if (a != null)
                    {
                        switch (a.actionType)
                        {
                            case actionEnum.playcard:
                                switch (a.card.card.CardId)
                                {
                                    case CardIds.Collectible.Priest.Entomb: goto case CardIds.Collectible.Rogue.GangUp;
                                    case CardIds.Collectible.Rogue.GangUp:
                                        if (a.target != null)
                                        {
                                            entityId = a.target.handcard.card.CardId;
                                        }

                                        break;
                                    case CardIds.Collectible.Mage.ForgottenTorch: entityId = "LOE_002t"; break;
                                    case CardIds.Collectible.Neutral.EliseStarseeker: entityId = "LOE_019t"; break;
                                    case CardIds.NonCollectible.Neutral.EliseStarseeker_MapToTheGoldenMonkeyToken: entityId = "LOE_019t2"; break;
                                    case CardIds.Collectible.Neutral.AncientShade: entityId = "LOE_110t"; break;
                                }
                                break;
                        }
                    }
                    if (entityId == "")
                    {
                        var oldCardsOut = Probabilitymaker.Instance.enemyCardsOut;
                        foreach (var tmp in eg)
                        {
                            if (oldCardsOut.ContainsKey(tmp.Key) && tmp.Value == oldCardsOut[tmp.Key])
                            {
                                continue;
                            }

                            switch (tmp.Key.CardId)
                            {
                                case CardIds.Collectible.Rogue.BeneathTheGrounds: entityId = "AT_035t"; break;
                                case CardIds.Collectible.Druid.Recycle: entityId = "aiextra1"; break;
                                case CardIds.Collectible.Priest.ExcavatedEvil: entityId = "LOE_111"; break;
                            }
                        }
                        if (entityId == "" && this.lastpf != null)
                        {
                            var num = 0;
                            foreach (var m in this.enemyMinions)
                            {
                                if (m.handcard.card.CardId == CardIds.Collectible.Warrior.IronJuggernaut)
                                {
                                    num++;
                                }
                            }
                            if (num > 0)
                            {
                                foreach (var m in this.lastpf.enemyMinions)
                                {
                                    if (m.handcard.card.CardId == CardIds.Collectible.Warrior.IronJuggernaut)
                                    {
                                        num--;
                                    }
                                }
                            }
                            if (num > 0)
                            {
                                entityId = "GVG_056t";
                            }
                            else
                            {
                                num = 0;
                                foreach (var m in this.lastpf.ownMinions)
                                {
                                    if (m.handcard.card.CardId == CardIds.Collectible.Druid.Malorne)
                                    {
                                        num++;
                                    }
                                }
                                if (num > 0)
                                {
                                    foreach (var m in this.ownMinions)
                                    {
                                        if (m.handcard.card.CardId == CardIds.Collectible.Druid.Malorne)
                                        {
                                            num--;
                                        }
                                    }
                                }
                                if (num > 0)
                                {
                                    entityId = "GVG_035";
                                }
                            }
                        }
                    }
                    if (entityId == "")
                    {
                        entityId = "aiextra1";
                    }
                }
                c.Value.setId(entityId);
                ce = (entityId);
                if (this.turnDeck.ContainsKey(ce))
                {
                    this.turnDeck[ce]++;
                }
                else
                {
                    this.turnDeck.Add(ce, 1);
                }
            }
            foreach (var c in tmpDeck)
            {
                if (c.Value < 1)
                {
                    continue;
                }

                SimCard ce = (c.Key);
                if (ce == SimCard.None)
                {
                    continue;
                }

                if (this.turnDeck.ContainsKey(ce))
                {
                    this.turnDeck[ce] += c.Value;
                }
                else
                {
                    this.turnDeck.Add(ce, c.Value);
                }
            }

            Probabilitymaker.Instance.setOwnCardsOut(og);
            Probabilitymaker.Instance.setEnemyCardsOut(eg);
            var isTurnStart = false;
            if (Ai.Instance.nextMoveGuess.mana == -100)
            {
                isTurnStart = true;
                Ai.Instance.updateTwoTurnSim();
            }
            Probabilitymaker.Instance.setGraveYard(graveYard, isTurnStart);

            if (this.startDeck.Count == 0)
            {
                return;
            }

            this.noDuplicates = true;
            foreach (var i in this.turnDeck.Values)
            {
                if (i > 1)
                {
                    this.noDuplicates = false;
                    break;
                }
            }
        }

        private void updateBehaveString(Behavior botbase)
        {
            this.botbehave = botbase.BehaviorName();
            this.botbehave += $" {Ai.Instance.maxwide}";
            this.botbehave += $" face {ComboBreaker.Instance.attackFaceHP}";
            if (Settings.Instance.berserkIfCanFinishNextTour > 0)
            {
                this.botbehave +=
                $" berserk:{Settings.Instance.berserkIfCanFinishNextTour}";
            }

            if (Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp > 0)
            {
                this.botbehave +=
                $" womob:{Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp}";
            }

            if (Settings.Instance.secondTurnAmount > 0)
            {
                if (Ai.Instance.nextMoveGuess.mana == -100)
                {
                    Ai.Instance.updateTwoTurnSim();
                }
                this.botbehave +=
                    $" twoturnsim {Settings.Instance.secondTurnAmount} ntss {Settings.Instance.nextTurnDeep} {Settings.Instance.nextTurnMaxWide} {Settings.Instance.nextTurnTotalBoards}";
            }

            if (Settings.Instance.playaround)
            {
                this.botbehave += " playaround";
                this.botbehave += $" {Settings.Instance.playaroundprob} {Settings.Instance.playaroundprob2}";
            }

            this.botbehave += $" ets {Settings.Instance.enemyTurnMaxWide}";

            if (Settings.Instance.twotsamount > 0)
            {
                this.botbehave += $" ets2 {Settings.Instance.enemyTurnMaxWideSecondStep}";
            }

            if (Settings.Instance.useSecretsPlayAround)
            {
                this.botbehave += " secret";
            }

            if (Settings.Instance.secondweight != 0.5f)
            {
                this.botbehave += $" weight {(int)(Settings.Instance.secondweight * 100f)}";
            }

            if (Settings.Instance.placement != 0)
            {
                this.botbehave += $" plcmnt:{Settings.Instance.placement}";
            }

            this.botbehave += $" iC {Settings.Instance.ImprovedCalculations}";

            this.botbehave += $" aA {Settings.Instance.adjustActions}";
            if (Settings.Instance.concedeMode != 0)
            {
                this.botbehave += $" cede:{Settings.Instance.concedeMode}";
            }
        }

        public void updateCThunInfo(int OgOwnCThunAngrBonus, int OgOwnCThunHpBonus, int OgOwnCThunTaunt)
        {
            this.anzOgOwnCThunAngrBonus = OgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = OgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = OgOwnCThunTaunt;
            Hrtprozis.Instance.updateCThunInfo(this.anzOgOwnCThunAngrBonus, this.anzOgOwnCThunHpBonus, this.anzOgOwnCThunTaunt);
        }

        public void updateCThunInfobyCThun()
        {
            var found = false;
            foreach (var hc in this.handCards)
            {
                if (hc.card.CardId == CardIds.Collectible.Neutral.Cthun)
                {
                    this.anzOgOwnCThunAngrBonus = hc.addattack;
                    this.anzOgOwnCThunHpBonus = hc.addHp;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                foreach (var m in this.ownMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.Cthun)
                    {
                        if (this.anzOgOwnCThunAngrBonus < m.Angr - 6)
                        {
                            this.anzOgOwnCThunAngrBonus = m.Angr - 6;
                        }

                        if (this.anzOgOwnCThunHpBonus < m.Hp - 6)
                        {
                            this.anzOgOwnCThunHpBonus = m.Angr - 6;
                        }

                        if (m.taunt && this.anzOgOwnCThunTaunt < 1)
                        {
                            this.anzOgOwnCThunTaunt++;
                        }

                        found = true;
                        break;
                    }
                }
            }
        }

        public static int getLastAffected(int entityid)
        {

            var allEntitys = TritonHs.GetAllCards();

            foreach (var ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.LAST_AFFECTED_BY) == entityid)
                {
                    return ent.GetTag(GAME_TAG.ENTITY_ID);
                }
            }

            return 0;
        }

        public static int getCardTarget(int entityid)
        {

            var allEntitys = TritonHs.GetAllCards();

            foreach (var ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.ENTITY_ID) == entityid)
                {
                    return ent.GetTag(GAME_TAG.CARD_TARGET);
                }
            }

            return 0;
        }


        private void printstuff()
        {


            var dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            var enemysecretIds = "";
            enemysecretIds = Probabilitymaker.Instance.getEnemySecretData();
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg($"开始计算, 已花费时间: {DateTime.Now:HH:mm:ss} V{this.versionnumber} {this.botbehave}");
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg($"turn {this.gTurn}/{this.gTurnStep}");
            Helpfunctions.Instance.logg($"mana {this.currentMana}/{this.ownMaxMana}");
            Helpfunctions.Instance.logg($"emana {this.enemyMaxMana}");
            Helpfunctions.Instance.logg($"own secretsCount: {this.ownSecretList.Count}");
            Helpfunctions.Instance.logg($"enemy secretsCount: {this.enemySecretList.Count} ;{enemysecretIds}");

            Ai.Instance.currentCalculatedBoard = dtimes;

            Hrtprozis.Instance.printHero();
            Hrtprozis.Instance.printOwnMinions();
            Hrtprozis.Instance.printEnemyMinions();
            Handmanager.Instance.printcards();
            Probabilitymaker.Instance.printTurnGraveYard();
            Probabilitymaker.Instance.printGraveyards();
            Hrtprozis.Instance.printOwnDeck();
        }
    }
}


