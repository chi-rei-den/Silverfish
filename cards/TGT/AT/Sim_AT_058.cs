using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_058",
  "name": [
    "皇家雷象",
    "King's Elekk"
  ],
  "text": [
    "<b>战吼：</b>揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，抽这张牌。",
    "<b>Battlecry:</b> Reveal a minion in each deck. If yours costs more, draw it."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2635
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_058 : SimTemplate //* King's Elekk
	{
		//Battlecry: Reveal a minion in each deck. If yours costs more, draw it.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.None, own.own);
		}
	}
}