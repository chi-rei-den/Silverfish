using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_035",
  "name": [
    "好奇的萤根草",
    "Curious Glimmerroot"
  ],
  "text": [
    "<b>战吼：</b>检视三张卡牌。猜中来自你对手的套牌中的卡牌，则将该牌的一张复制置入你的手牌。",
    "[x]<b>Battlecry:</b> Look at 3 cards.\nGuess which one started\nin your opponent's deck\nto get a copy of it."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41177
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_035 : SimTemplate //* Curious Glimmerroot
	{
		//Battlecry: Look at 3 cards. Guess which one started in your opponent's deck to get a copy of it.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.None, own.own, true);
		}
	}
}