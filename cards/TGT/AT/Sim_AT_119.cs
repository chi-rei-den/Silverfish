using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_119",
  "name": [
    "克瓦迪尔劫掠者",
    "Kvaldir Raider"
  ],
  "text": [
    "<b>激励：</b>获得+2/+2。",
    "<b>Inspire:</b> Gain +2/+2."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2511
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_119 : SimCard //* Kvaldir Raider
	{
		//Inspire: Gain +2/+2.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetBuffed(m, 2, 2);
			}
        }
	}
}