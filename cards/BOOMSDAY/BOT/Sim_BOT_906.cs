using System;
using System.Collections.Generic;
using System.Text;



/* _BEGIN_TEMPLATE_
{
  "id": "BOT_906",
  "name": [
    "格洛顿",
    "Glow-Tron"
  ],
  "text": [
    "<b>磁力</b>",
    "<b>Magnetic</b>"
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48982
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_906 : SimCard //* 格洛顿 Glow-Tron
	{
		//<b>Magnetic</b>
		//<b>磁力</b>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}