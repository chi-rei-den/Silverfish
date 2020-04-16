using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_238",
  "name": [
    "活化狂战士",
    "Animated Berserker"
  ],
  "text": [
    "在你使用一张随从牌后，对被召唤的随从造成1点伤害。",
    "After you play a minion, deal 1 damage to it."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42810
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_238: SimTemplate //* Animated Berserker
    {
        // After you play a minion deal 1 damage to it.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.playedFromHand && summonedMinion.own == m.own && summonedMinion.entitiyID != m.entitiyID)
            {
                p.minionGetDamageOrHeal(summonedMinion, 1);
            }
        }
    }
}