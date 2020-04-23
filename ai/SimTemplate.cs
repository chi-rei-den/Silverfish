using Chireiden.Silverfish;

namespace HREngine.Bots
{
    public class SimTemplate
    {
        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, int number)
        {
        }

        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
        }

        public virtual bool onCardDicscard(Playfield p, Handcard hc, Minion own, int num, bool checkBonus = false)
        {
            return false;
        }

        public virtual void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
        }

        public virtual void onAuraStarts(Playfield p, Minion m)
        {
        }

        public virtual void onAuraEnds(Playfield p, Minion m)
        {
        }

        public virtual void onEnrageStart(Playfield p, Minion m)
        {
        }

        public virtual void onEnrageStop(Playfield p, Minion m)
        {
        }

        public virtual void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
        }

        public virtual void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
        }

        public virtual void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
        }

        public virtual void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
        }

        public virtual void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
        }

        public virtual void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
        }

        public virtual void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
        }

        public virtual void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
        }

        public virtual void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
        }

        public virtual void onDeathrattle(Playfield p, Minion m)
        {
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Handcard triggerhc)
        {
        }

        public virtual void onCardWasPlayed(Playfield p, SimCard c, bool wasOwnCard, Minion triggerEffectMinion)
        {
        }

        public virtual void onInspire(Playfield p, Minion m, bool ownerOfInspire)
        {
        }

        public virtual void onMinionLosesDivineShield(Playfield p, Minion m, int num)
        {
        }
    }
}