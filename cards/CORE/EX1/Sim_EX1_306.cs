using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_306",
  "name": [
    "魔犬",
    "Felstalker"
  ],
  "text": [
    "<b>战吼：</b>\n随机弃一张牌。",
    "<b>Battlecry:</b> Discard a random card."
  ],
  "CardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 592
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_306 : SimTemplate //* Succubus
	{
        // Battlecry: Discard a random card.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.discardCards(1, own.own);
		}
	}
}