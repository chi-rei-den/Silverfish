using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_089",
  "name": [
    "白骨卫士军官",
    "Boneguard Lieutenant"
  ],
  "text": [
    "<b>激励：</b>\n获得+1生命值。",
    "<b>Inspire:</b> Gain +1 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2495
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_089 : SimTemplate //* Boneguard Lieutenant
	{
		//Inspire: Gain +1 Health

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetBuffed(m, 0, 1);
			}
        }
	}
}