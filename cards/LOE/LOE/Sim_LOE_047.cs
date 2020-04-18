using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_047",
  "name": [
    "墓穴蜘蛛",
    "Tomb Spider"
  ],
  "text": [
    "<b>战吼：\n发现</b>一张野兽牌。",
    "<b>Battlecry: Discover</b> a Beast."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2919
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_047 : SimTemplate //* Tomb Spider
	{
		//Battlecry: Discover a Beast.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardIds.Collectible.Neutral.RiverCrocolisk, own.own, true);
		}
	}
}