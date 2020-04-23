using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_075",
  "name": [
    "船载火炮",
    "Ship's Cannon"
  ],
  "text": [
    "在你召唤一个海盗后，随机对一个敌人造成2点伤害。",
    "[x]After you summon a\nPirate, deal 2 damage\nto a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2043
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    internal class Sim_GVG_075 : SimTemplate //* Ship's Cannon
    {
        //   Whenever you summon a Pirate, deal 2 damage to a random enemy.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (summonedMinion.handcard.card.Race == Race.PIRATE && triggerEffectMinion.own == summonedMinion.own)
            {
                Minion target = null;

                if (triggerEffectMinion.own)
                {
                    target = p.getEnemyCharTargetForRandomSingleDamage(2);
                }
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, SearchMode.HighAttack); //damage the Highest (pessimistic)
                    if (target == null)
                    {
                        target = p.ownHero;
                    }
                }

                p.minionGetDamageOrHeal(target, 2, true);
            }
        }
    }
}