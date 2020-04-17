using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_075",
  "name": [
    "卑鄙的恐惧魔王",
    "Despicable Dreadlord"
  ],
  "text": [
    "在你的回合结束时，对所有敌方随从造成1点伤害。",
    "At the end of your turn, deal 1 damage to all enemy minions."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42743
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_075: SimCard //* Despicable Dreadlord
    {
        // At the end of your turn, deal 1 damage to all enemy minions.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.allMinionOfASideGetDamage(!triggerEffectMinion.own, 1);
            }
        }
    }
}