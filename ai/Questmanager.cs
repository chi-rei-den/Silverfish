using HearthDb.Enums;
using Chireiden.Silverfish;
using HearthDb;
namespace HREngine.Bots
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Questmanager
    {
        public class QuestItem
        {
            public Dictionary<SimCard, int> mobsTurn = new Dictionary<SimCard, int>();
            public SimCard Id = SimCard.None;
            public int questProgress = 0;
            public int maxProgress = 1000;

            public QuestItem()
            {
            }

            public void Copy(QuestItem q)
            {
                this.Id = q.Id;
                this.questProgress = q.questProgress;
                this.maxProgress = q.maxProgress;
                if (Id == CardIds.Collectible.Rogue.TheCavernsBelow)
                {
                    this.mobsTurn.Clear();
                    foreach (var n in q.mobsTurn) this.mobsTurn.Add(n.Key, n.Value);
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
                String[] q = s.Split(' ');
                this.Id = (q[0]);
                this.questProgress = Convert.ToInt32(q[1]);
                this.maxProgress = Convert.ToInt32(q[2]);
            }

            //-!!!!set in code check if (this.enemyQuest.Id != SimCard.None)
            public void trigger_MinionWasPlayed(Minion m)
            {
                switch (Id.CardId)
                {
                    case CardIds.Collectible.Warrior.FirePlumesHeart: if (m.taunt) questProgress++; break;
                    case CardIds.Collectible.Hunter.TheMarshQueen: if (m.handcard.card.Cost == 1) questProgress++; break;
                    case CardIds.Collectible.Rogue.TheCavernsBelow:
                        if (mobsTurn.ContainsKey(m.name)) mobsTurn[m.name]++;
                        else mobsTurn.Add(m.name, 1);
                        int total = mobsTurn[m.name] + Questmanager.Instance.getPlayedCardFromHand(m.name);
                        if (total > questProgress) questProgress++;
                        break;
                }
            }

            public void trigger_MinionWasSummoned(Minion m)
            {
                switch (Id.CardId)
                {
                    case CardIds.Collectible.Druid.JungleGiants: if (m.Angr >= 5) questProgress++; break;
                    case CardIds.Collectible.Priest.AwakenTheMakers: if (m.handcard.card.Deathrattle) questProgress++; break;
                    case CardIds.Collectible.Shaman.UniteTheMurlocs: if ((Race)m.handcard.card.Race == Race.MURLOC) questProgress++; break;
                }
            }

            public void trigger_SpellWasPlayed(Minion target, int qId)
            {
                switch (Id.CardId)
                {
                    case CardIds.Collectible.Paladin.TheLastKaleidosaur: if (target != null && target.own && !target.isHero) questProgress++; break;
                    case CardIds.Collectible.Mage.OpenTheWaygate: if (qId > 67) questProgress++; break;
                }
            }

            public void trigger_WasDiscard(int num)
            {
                switch (Id.CardId)
                {
                    case CardIds.Collectible.Warlock.LakkariSacrifice: questProgress += num; break;
                }
            }

            public SimCard Reward()
            {
                switch (Id.CardId)
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
        private int nextMobId = 0;
        private int prevMobId = 0;
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
            QuestItem tmp = new QuestItem() { Id = (questID), questProgress = curProgr, maxProgress = maxProgr };
            if (ownplay) this.ownQuest = tmp;
            else this.enemyQuest = tmp;
        }

        public void updatePlayedMobs(int step)
        {
            if (step != 0)
            {
                if (nextMobName != SimCard.None && nextMobId != prevMobId)
                {
                    prevMobId = nextMobId;
                    nextMobId = 0;
                    if (mobsGame.ContainsKey(nextMobName))
                    {
                        if (ownQuest.questProgress > mobsGame[nextMobName]) mobsGame[nextMobName]++;
                        else mobsGame[nextMobName] = ownQuest.questProgress;
                    }
                    else mobsGame.Add(nextMobName, 1);
                }
            }
        }

        public void updatePlayedCardFromHand(Handmanager.Handcard hc)
        {
            nextMobName = SimCard.None;
            nextMobId = 0;
            if (hc != null && hc.card.Type == CardType.MINION)
            {
                nextMobName = hc.card.CardId;
                nextMobId = hc.entity;
            }
        }

        public int getPlayedCardFromHand(SimCard name)
        {
            if (mobsGame.ContainsKey(name)) return mobsGame[name];
            else return 0;
        }

        public void Reset()
        {
            sb.Clear();
            mobsGame.Clear();
            ownQuest = new QuestItem();
            enemyQuest = new QuestItem();
            nextMobName = SimCard.None;
            nextMobId = 0;
            prevMobId = 0;
        }

        public string getQuestsString()
        {
            sb.Clear();
            sb.Append("quests: ");
            sb.Append(ownQuest.Id).Append(" ").Append(ownQuest.questProgress).Append(" ").Append(ownQuest.maxProgress).Append(" ");
            sb.Append(enemyQuest.Id).Append(" ").Append(enemyQuest.questProgress).Append(" ").Append(enemyQuest.maxProgress);
            return sb.ToString();
        }


    }

}