using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_255",
  "name": [
    "厄运召唤者",
    "Doomcaller"
  ],
  "text": [
    "<b>战吼：</b>使你的克苏恩获得+2/+2<i>（无论它在哪里）。</i>如果克苏恩死亡，将其洗入你的牌库。",
    "<b>Battlecry:</b> Give your C'Thun +2/+2 <i>(wherever it is).</i> If it's dead, shuffle it into your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38795
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_255 : SimTemplate //* Doomcaller
	{
		//Battlecry: Give your C'Thun +2/+2 (wherever it is). If it's dead, shuffle it into your deck.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.cthunGetBuffed(2, 2, 0);
		}
	}
}