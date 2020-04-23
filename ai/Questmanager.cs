using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

namespace HREngine.Bots
{
    public class Questmanager
    {
        public class QuestItem
        {
            public Dictionary<SimCard, int> mobsTurn = new Dictionary<SimCard, int>();
            public SimCard Id = SimCard.None;
            public int questProgress;
            public int maxProgress = 1000;

            public QuestItem()
            {
            }

            public void Copy(QuestItem q)
            {
                this.Id = q.Id;
                this.questProgress = q.questProgress;
                this.maxProgress = q.maxProgress;
                if (this.Id == CardIds.Collectible.Rogue.TheCavernsBelow)
                {
                    this.mobsTurn.Clear();
                    foreach (var n in q.mobsTurn)
                    {
                        this.mobsTurn.Add(n.Key, n.Value);
                    }
                }
            }

            public void Reset()
            {
                this.Id = SimCard.None;
                this.questProgress = 0;
                this.maxProgress = 1000;
                this.mobsTurn.Clear();
            }

            public QuestItem(string s)
            {
                var q = s.Split(' ');
                this.Id = q[0];
                this.questProgress = Convert.ToInt32(q[1]);
                this.maxProgress = Convert.ToInt32(q[2]);
            }

            //-!!!!set in code check if (this.enemyQuest.Id != SimCard.None)
            public void trigger_MinionWasPlayed(Minion m)
            {
                switch (this.Id.CardId)
                {
                    case CardIds.Collectible.Warrior.FirePlumesHeart:
                        if (m.taunt)
                        {
                            this.questProgress++;
                        }

                        break;
                    case CardIds.Collectible.Hunter.TheMarshQueen:
                        if (m.handcard.card.Cost == 1)
                        {
                            this.questProgress++;
                        }

                        break;
                    case CardIds.Collectible.Rogue.TheCavernsBelow:
                        if (this.mobsTurn.ContainsKey(m.name))
                        {
                            this.mobsTurn[m.name]++;
                        }
                        else
                        {
                            this.mobsTurn.Add(m.name, 1);
                        }

                        var total = this.mobsTurn[m.name] + Instance.getPlayedCardFromHand(m.name);
                        if (total > this.questProgress)
                        {
                            this.questProgress++;
                        }

                        break;
                }
            }

            public void trigger_MinionWasSummoned(Minion m)
            {
                switch (this.Id.CardId)
                {
                    case CardIds.Collectible.Druid.JungleGiants:
                        if (m.Angr >= 5)
                        {
                            this.questProgress++;
                        }

                        break;
                    case CardIds.Collectible.Priest.AwakenTheMakers:
                        if (m.handcard.card.Deathrattle)
                        {
                            this.questProgress++;
                        }

                        break;
                    case CardIds.Collectible.Shaman.UniteTheMurlocs:
                        if (m.handcard.card.Race == Race.MURLOC)
                        {
                            this.questProgress++;
                        }

                        break;
                }
            }

            public void trigger_SpellWasPlayed(Minion target, int qId)
            {
                switch (this.Id.CardId)
                {
                    case CardIds.Collectible.Paladin.TheLastKaleidosaur:
                        if (target != null && target.own && !target.isHero)
                        {
                            this.questProgress++;
                        }

                        break;
                    case CardIds.Collectible.Mage.OpenTheWaygate:
                        if (qId > 67)
                        {
                            this.questProgress++;
                        }

                        break;
                }
            }

            public void trigger_WasDiscard(int num)
            {
                switch (this.Id.CardId)
                {
                    case CardIds.Collectible.Warlock.LakkariSacrifice:
                        this.questProgress += num;
                        break;
                }
            }

            public SimCard Reward()
            {
                switch (this.Id.CardId)
                {
                    case CardIds.Collectible.Mage.OpenTheWaygate: return CardIds.NonCollectible.Mage.OpentheWaygate_TimeWarpToken; //-Quest: Cast 6 spells that didn't start in your deck. Reward: Time Warp.
                    case CardIds.Collectible.Rogue.TheCavernsBelow: return CardIds.NonCollectible.Rogue.TheCavernsBelow_CrystalCoreTokenUNGORO; //-Quest: Play four minions with the same name. Reward: Crystal Core.
                    case CardIds.Collectible.Druid.JungleGiants: return CardIds.NonCollectible.Druid.JungleGiants_BarnabusTheStomperToken; //-Quest: Summon 5 minions with 5 or more Attack. Reward: Barnabus.
                    case CardIds.Collectible.Warlock.LakkariSacrifice: return CardIds.NonCollectible.Warlock.LakkariSacrifice_NetherPortalToken1; //-Quest: Discard 6 cards. Reward: Nether Portal.
                    case CardIds.Collectible.Hunter.TheMarshQueen: return CardIds.NonCollectible.Hunter.TheMarshQueen_QueenCarnassaToken; //-Quest: Play seven 1-Cost minions. Reward: Queen Carnassa.
                    case CardIds.Collectible.Warrior.FirePlumesHeart: return CardIds.NonCollectible.Warrior.FirePlumesHeart_SulfurasToken; //-Quest: Play 7 Taunt minions. Reward: Sulfuras.
                    case CardIds.Collectible.Priest.AwakenTheMakers: return CardIds.NonCollectible.Priest.AwakentheMakers_AmaraWardenOfHopeToken; //-Quest: Summon 7 Deathrattle minions. Reward: Amara, Warden of Hope.
                    case CardIds.Collectible.Shaman.UniteTheMurlocs: return CardIds.NonCollectible.Shaman.UnitetheMurlocs_MegafinToken; //-Quest: Summon 10 Murlocs. Reward: Megafin.
                    case CardIds.Collectible.Paladin.TheLastKaleidosaur: return CardIds.NonCollectible.Paladin.TheLastKaleidosaur_GalvadonToken; //-Quest: Cast 6 spells on your minions. Reward: Galvadon.
                }

                return SimCard.None;
            }
        }

        StringBuilder sb = new StringBuilder("", 500);
        public QuestItem ownQuest = new QuestItem();
        public QuestItem enemyQuest = new QuestItem();
        public Dictionary<SimCard, int> mobsGame = new Dictionary<SimCard, int>();
        private SimCard nextMobName = SimCard.None;
        private int nextMobId;
        private int prevMobId;
        Helpfunctions help;

        private static Questmanager instance;

        public static Questmanager Instance
        {
            get
            {
                return instance ?? (instance = new Questmanager());
            }
        }

        private Questmanager()
        {
            this.help = Helpfunctions.Instance;
        }

        public void updateQuestStuff(string questID, int curProgr, int maxProgr, bool ownplay)
        {
            var tmp = new QuestItem {Id = questID, questProgress = curProgr, maxProgress = maxProgr};
            if (ownplay)
            {
                this.ownQuest = tmp;
            }
            else
            {
                this.enemyQuest = tmp;
            }
        }

        public void updatePlayedMobs(int step)
        {
            if (step != 0)
            {
                if (this.nextMobName != SimCard.None && this.nextMobId != this.prevMobId)
                {
                    this.prevMobId = this.nextMobId;
                    this.nextMobId = 0;
                    if (this.mobsGame.ContainsKey(this.nextMobName))
                    {
                        if (this.ownQuest.questProgress > this.mobsGame[this.nextMobName])
                        {
                            this.mobsGame[this.nextMobName]++;
                        }
                        else
                        {
                            this.mobsGame[this.nextMobName] = this.ownQuest.questProgress;
                        }
                    }
                    else
                    {
                        this.mobsGame.Add(this.nextMobName, 1);
                    }
                }
            }
        }

        public void updatePlayedCardFromHand(Handcard hc)
        {
            this.nextMobName = SimCard.None;
            this.nextMobId = 0;
            if (hc != null && hc.card.Type == CardType.MINION)
            {
                this.nextMobName = hc.card.CardId;
                this.nextMobId = hc.entity;
            }
        }

        public int getPlayedCardFromHand(SimCard name)
        {
            if (this.mobsGame.ContainsKey(name))
            {
                return this.mobsGame[name];
            }

            return 0;
        }

        public void Reset()
        {
            this.sb.Clear();
            this.mobsGame.Clear();
            this.ownQuest = new QuestItem();
            this.enemyQuest = new QuestItem();
            this.nextMobName = SimCard.None;
            this.nextMobId = 0;
            this.prevMobId = 0;
        }

        public string getQuestsString()
        {
            this.sb.Clear();
            this.sb.Append("quests: ");
            this.sb.Append(this.ownQuest.Id).Append(" ").Append(this.ownQuest.questProgress).Append(" ").Append(this.ownQuest.maxProgress).Append(" ");
            this.sb.Append(this.enemyQuest.Id).Append(" ").Append(this.enemyQuest.questProgress).Append(" ").Append(this.enemyQuest.maxProgress);
            return this.sb.ToString();
        }
    }
}