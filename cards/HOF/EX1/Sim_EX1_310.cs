using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_310",
  "name": [
    "末日守卫",
    "Doomguard"
  ],
  "text": [
    "<b>冲锋</b>，<b>战吼：</b>随机弃两张牌。",
    "<b>Charge</b>. <b>Battlecry:</b> Discard two random cards."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 631
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_310 : SimCard //* Doomguard
	{
        // Charge. Battlecry: Discard two random cards.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(2, own.own);
		}
	}
}