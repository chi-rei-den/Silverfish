using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_079",
  "name": [
    "伊莉斯·逐星",
    "Elise Starseeker"
  ],
  "text": [
    "<b>战吼：</b>将“黄金猿藏宝图”洗入你的牌库。",
    "<b>Battlecry:</b> Shuffle the 'Map to the Golden Monkey'   into your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2951
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_079 : SimCard //* Elise Starseeker
	{
		//Battlecry: Shuffle the 'Map to the Golden Monkey' into your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 6;
			}
            else p.enemyDeckSize++;
        }
    }
}