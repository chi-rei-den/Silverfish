using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_063t",
  "name": [
    "恐鳞",
    "Dreadscale"
  ],
  "text": [
    "在你的回合结束时，对所有其他随从造成\n1点伤害。",
    "At the end of your turn, deal 1 damage to all other minions."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2634
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_063t : SimCard //* Dreadscale
	{
		//At the end of your turn, deal 1 damage to all other minions.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.allMinionsGetDamage(1, triggerEffectMinion.entitiyID);
            }
        }
	}
}