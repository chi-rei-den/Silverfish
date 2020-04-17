using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_833",
  "name": [
    "拉卡利地狱犬",
    "Lakkari Felhound"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>\n随机弃两张牌。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Discard two random cards."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41873
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_833 : SimCard //* Lakkari Felhound
	{
		//Taunt. Battlecry: Discard two random cards.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.discardCards(2, own.own);
        }
    }
}