using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_030a",
  "name": [
    "橱柜蜘蛛",
    "Pantry Spider"
  ],
  "text": [
    "<b>战吼：</b>召唤一只1/3的蜘蛛。",
    "<b>Battlecry:</b> Summon a\n1/3 Spider."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39207
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_030a : SimTemplate //* Pantry Spider
	{
		//Battlecry: Summon a 1/3 Spider.
		
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.CellarSpider;//Cellar Spider
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own);
		}
	}
}