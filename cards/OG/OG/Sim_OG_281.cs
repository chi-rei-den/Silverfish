using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_281",
  "name": [
    "邪灵召唤师",
    "Beckoner of Evil"
  ],
  "text": [
    "<b>战吼：</b>使你的克苏恩获得+2/+2<i>（无论它在哪里）。</i>",
    "<b>Battlecry:</b> Give your C'Thun +2/+2 <i>(wherever it is).</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38859
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_281 : SimCard //* Beckoner of Evil
	{
		//Battlecry: Give your C'Thun +2/+2 (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.cthunGetBuffed(2, 2, 0);
            }
		}
	}
}