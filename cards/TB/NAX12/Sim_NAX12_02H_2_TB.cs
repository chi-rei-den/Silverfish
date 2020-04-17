using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX12_02H_2_TB",
  "name": [
    "残杀",
    "Decimate"
  ],
  "text": [
    "<b>英雄技能</b>\n将所有敌方随从的生命值变为1。",
    "<b>Hero Power</b>\nChange the Health of enemy minions to 1."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 31347
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX12_02H_2_TB : SimCard //* Decimate
	{
		// Hero Power: Change the Health of enemy minions to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in ownplay ? p.enemyMinions : p.ownMinions)
            {
                p.minionSetLifetoX(m, 1);
            }
		}
	}
}