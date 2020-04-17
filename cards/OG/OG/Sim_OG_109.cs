using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_109",
  "name": [
    "夜色镇图书管理员",
    "Darkshire Librarian"
  ],
  "text": [
    "<b>战吼：</b>\n随机弃一张牌。\n<b>亡语：</b>\n抽一张牌。",
    "<b>Battlecry:</b>\nDiscard a random card. <b>Deathrattle:</b>\nDraw a card."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38447
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_109 : SimCard //* Darkshire Librarian
    {
        //Battlecry: Discard a random card. Deathrattle: Draw a card.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.None, m.own);
        }

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(1, own.own);
        }
    }
}