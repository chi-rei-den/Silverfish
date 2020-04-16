using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_920t1",
  "name": [
    "卡纳莎女王",
    "Queen Carnassa"
  ],
  "text": [
    "<b>战吼：</b>将15张迅猛龙牌洗入你的牌库。",
    "<b>Battlecry:</b> Shuffle 15 Raptors into your deck."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41367
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_920t1 : SimTemplate //* Queen Carnassa
	{
		//Battlecry: Shuffle 15 Raptors into your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
			{
				p.ownDeckSize += 15;
				p.evaluatePenality -= 20;
			}
		}
	}
}