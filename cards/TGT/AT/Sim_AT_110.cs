using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_110",
  "name": [
    "角斗场主管",
    "Coliseum Manager"
  ],
  "text": [
    "<b>激励：</b>将该随从移回你的手牌。",
    "<b>Inspire:</b> Return this minion to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2585
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_110 : SimTemplate //* Coliseum Manager
	{
		//Inspire: Return this minion to your hand.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionReturnToHand(m, own, 0);
			}
        }
	}
}