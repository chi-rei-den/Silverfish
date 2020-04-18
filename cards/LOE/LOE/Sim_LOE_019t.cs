using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_019t",
  "name": [
    "黄金猿藏宝图",
    "Map to the Golden Monkey"
  ],
  "text": [
    "将“黄金猿”洗入你的牌库。抽一张牌。",
    "Shuffle the Golden Monkey into your deck. Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 2992
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_019t : SimTemplate //* Map to the Golden Monkey
	{
		//Shuffle the Golden Monkey into your deck. Draw a card.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
			{
				p.ownDeckSize++;
				p.evaluatePenality -= 12;
			}
            else p.enemyDeckSize++;
			
			p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
		}
	}
}