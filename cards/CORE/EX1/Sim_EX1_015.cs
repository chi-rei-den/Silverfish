using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_015",
  "name": [
    "工程师学徒",
    "Novice Engineer"
  ],
  "text": [
    "<b>战吼：</b>抽一张牌。",
    "<b>Battlecry:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 284
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_015 : SimCard //noviceengineer
	{

//    kampfschrei:/ zieht eine karte.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own);
		}


	}
}