using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_014",
  "name": [
    "穆克拉",
    "King Mukla"
  ],
  "text": [
    "<b>战吼：</b>使你的对手获得两个香蕉。",
    "<b>Battlecry:</b> Give your opponent 2 Bananas."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1693
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_014 : SimCard //kingmukla
	{

//    kampfschrei:/ gebt eurem gegner 2 bananen.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }
            p.drawACard(CardDB.cardName.bananas, !own.own, true);
            if (own.own)
            {
                p.enemycarddraw -= 1;
            }
		}


	}
}