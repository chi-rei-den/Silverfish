using Silverfish;

namespace HREngine.Bots
{
    public class SimCard
    {
        public static SimCard FromName(string name)
        {
            if (!Cards.Collectible.TryGetValue(name, out var card) && !Cards.All.TryGetValue(name, out card))
            {
                card = Cards.GetFromName(name, Locale.enUS)
                ?? Cards.GetFromName(name, Locale.zhCN)
                ?? Cards.GetFromName(name, Locale.enUS, false)
                ?? Cards.GetFromName(name, Locale.zhCN, false);
            }
            return card != null ? new SimCard { CardDef = card } : null;
        }

        public Card CardDef { get; private set; }

        public bool Charge => Convert.ToBoolean(this.CardDef.Entity.GetTag(GameTag.CHARGE));

        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            return;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            return;
        }

        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            return;
        }

        public virtual bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus = false)
        {
            return false;
        }

        public virtual void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            return;
        }

        public virtual void onAuraStarts(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onAuraEnds(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onEnrageStart(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onEnrageStop(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
            return;
        }

        public virtual void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            return;
        }
        public virtual void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            return;
        }

        public virtual void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            return;
        }

        public virtual void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            return;
        }

        public virtual void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            return;
        }

        public virtual void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            return;
        }

        public virtual void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onDeathrattle(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            return;
        }

        public virtual void onCardWasPlayed(Playfield p, SimCard c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        public virtual void onInspire(Playfield p, Minion m, bool ownerOfInspire)
        {
            return;
        }

        public virtual void onMinionLosesDivineShield(Playfield p, Minion m, int num)
        {
            return;
        }
    }
}