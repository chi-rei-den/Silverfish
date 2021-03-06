using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_020",
  "name": [
    "邪能火炮",
    "Fel Cannon"
  ],
  "text": [
    "在你的回合结束时，对一个非机械随从造成2点伤害。",
    "At the end of your turn, deal 2 damage to a non-Mech minion."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1997
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_020 : SimTemplate //Fel Cannon
    {
        //    At the end of your turn, deal 2 damage to a non-Mech minion.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                //count non-mechs
                var ownNonMechs = 0;
                Minion ownTemp = null;
                foreach (var m in p.ownMinions)
                {
                    if (m.handcard.card.Race != Race.MECHANICAL)
                    {
                        if (ownTemp == null)
                        {
                            ownTemp = m;
                        }

                        ownNonMechs++;
                    }
                }

                var enemyNonMechs = 0;
                Minion enemyTemp = null;
                foreach (var m in p.enemyMinions)
                {
                    if (m.handcard.card.Race != Race.MECHANICAL)
                    {
                        if (enemyTemp == null)
                        {
                            enemyTemp = m;
                        }

                        enemyNonMechs++;
                    }
                }

                // dmg own minion if we have more than the enemy, in the other case dmg him!
                if (ownNonMechs >= 1 && enemyNonMechs >= 1)
                {
                    if (ownNonMechs >= enemyNonMechs)
                    {
                        p.minionGetDamageOrHeal(ownTemp, 2, true);
                        return;
                    }

                    p.minionGetDamageOrHeal(enemyTemp, 2, true);
                    return;
                }

                if (ownNonMechs >= 1)
                {
                    p.minionGetDamageOrHeal(ownTemp, 2, true);
                    return;
                }

                if (enemyNonMechs >= 1)
                {
                    p.minionGetDamageOrHeal(enemyTemp, 2, true);
                }
            }
        }
    }
}