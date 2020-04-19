using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_151",
  "name": [
    "白银之手骑士",
    "Silver Hand Knight"
  ],
  "text": [
    "<b>战吼：</b>召唤一个2/2的侍从。",
    "<b>Battlecry:</b> Summon a 2/2 Squire."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 69
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_151 : SimTemplate //silverhandknight
	{
        SimCard kid = CardIds.NonCollectible.Neutral.Squire;//squire
//    kampfschrei:/ ruft einen knappen (2/2) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own);
		}

	}
}