using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_283",
  "name": [
    "克苏恩的侍从",
    "C'Thun's Chosen"
  ],
  "text": [
    "<b>圣盾</b>，<b>战吼：</b>使你的克苏恩获得+2/+2<i>（无论它在哪里）。</i>",
    "[x]<b>Divine Shield</b>\n<b>Battlecry:</b> Give your C'Thun\n+2/+2 <i>(wherever it is).</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38863
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_283 : SimCard //* C'Thun's Chosen
	{
		//Divine Shield. Battlecry: Give your C'Thun +2/+2 (wherever it is).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.cthunGetBuffed(2, 2, 0);
		}
	}
}