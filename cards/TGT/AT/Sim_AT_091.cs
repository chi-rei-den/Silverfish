using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_091",
  "name": [
    "赛场医师",
    "Tournament Medic"
  ],
  "text": [
    "<b>激励：</b>为你的英雄恢复#2点生命值。",
    "<b>Inspire:</b> Restore #2 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2575
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_091 : SimCard //* Tournament Medic
	{
		//Inspire: Restore 2 Health to your Hero.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				int heal = (own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
				p.minionGetDamageOrHeal(own ? p.ownHero : p.enemyHero, -heal);
			}
        }
	}
}