using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_112",
  "name": [
    "格尔宾·梅卡托克",
    "Gelbin Mekkatorque"
  ],
  "text": [
    "<b>战吼：</b>进行一次惊人的发明。",
    "<b>Battlecry:</b> Summon an AWESOME invention."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 858
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_112 : SimTemplate //gelbinmekkatorque
	{
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.HomingChicken;//homingchicken
//    kampfschrei:/ konstruiert eine fantastische erfindung.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own);
		}


	}
}