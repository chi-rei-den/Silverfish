using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_023",
  "name": [
    "黑市摊贩",
    "Dark Peddler"
  ],
  "text": [
    "<b>战吼：发现</b>一张\n法力值消耗为（1）的卡牌。",
    "<b>Battlecry: Discover</b> a\n1-Cost card."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2895
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_023 : SimTemplate //* Dark Peddler
	{
		//Battlecry: Discover a (1)-cost card.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardIds.Collectible.Neutral.LeperGnome, own.own, true);
		}
	}
}