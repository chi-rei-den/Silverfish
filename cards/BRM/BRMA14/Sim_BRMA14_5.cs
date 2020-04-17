using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA14_5",
  "name": [
    "剧毒金刚",
    "Toxitron"
  ],
  "text": [
    "在你的回合开始时，对所有其他随从造成1点伤害。",
    "At the start of your turn, deal 1 damage to all other minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2391
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA14_5 : SimCard //* 3/3 toxitron
	{
		// At the start of your turn, deal 1 damage to all other minions.

		public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
		{
		   if (triggerEffectMinion.own == turnStartOfOwner)
           {
               p.allMinionsGetDamage(1, triggerEffectMinion.entitiyID);
		   }
		}

	}
}