using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_113",
  "name": [
    "热情的探险家",
    "Bright-Eyed Scout"
  ],
  "text": [
    "<b>战吼：</b>抽一张牌，使其法力值消耗变为（5）点。",
    "<b>Battlecry:</b> Draw a card. Change its Cost to (5)."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41096
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_113 : SimTemplate //* Bright-Eyed Scout
	{
		//Battlecry: Draw a card. Change its Cost to (5).

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own);
                p.owncards[p.owncards.Count - 1].manacost = 5;
		}
	}
}