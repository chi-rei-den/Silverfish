using System;
using System.Collections.Generic;
using System.Text;



/* _BEGIN_TEMPLATE_
{
  "id": "BOT_563",
  "name": [
    "战争机兵",
    "Wargear"
  ],
  "text": [
    "<b>磁力</b>",
    "<b>Magnetic</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 49356
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_563 : SimCard //* 战争机兵 Wargear
	{
		//<b>Magnetic</b>
		//<b>磁力</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}