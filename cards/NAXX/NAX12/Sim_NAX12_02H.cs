using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX12_02H",
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
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2141
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX12_02H : SimCard //* Decimate
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