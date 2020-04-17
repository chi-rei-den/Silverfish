using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_561",
  "name": [
    "阿莱克丝塔萨",
    "Alexstrasza"
  ],
  "text": [
    "<b>战吼：</b>\n将一方英雄的剩余生命值变为15。",
    "<b>Battlecry:</b> Set a hero's remaining Health to 15."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 581
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_561 : SimCard //alexstrasza
	{

//    kampfschrei:/ setzt das verbleibende leben eines helden auf 15.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            target.Hp = 15;
		}


	}
}