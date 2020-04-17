using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_920t2",
  "name": [
    "卡纳莎的族群",
    "Carnassa's Brood"
  ],
  "text": [
    "<b>战吼：</b>抽一张牌。",
    "<b>Battlecry:</b> Draw a card."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 42013
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_920t2 : SimCard //* Carnassa's Brood
	{
		//Battlecry: Draw a card.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own);
		}
	}
}