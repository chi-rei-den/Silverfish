using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_108",
  "name": [
    "重甲战马",
    "Armored Warhorse"
  ],
  "text": [
    "<b>战吼：</b>揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，则获得<b>冲锋</b>。",
    "<b>Battlecry:</b> Reveal a minion in each deck. If yours costs more, gain <b>Charge</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2627
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_108 : SimCard //* Armored Warhorse
	{
		//Battlecry: Reveal a minion in each deck.If yours costs more, gain Charge.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetCharge(own); // optimistic
		}
	}
}