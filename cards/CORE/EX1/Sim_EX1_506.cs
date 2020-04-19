using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_506",
  "name": [
    "鱼人猎潮者",
    "Murloc Tidehunter"
  ],
  "text": [
    "<b>战吼：</b>召唤一个1/1的鱼人斥候。",
    "<b>Battlecry:</b> Summon a 1/1 Murloc Scout."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 976
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_506 : SimTemplate //murloctidehunter
	{
        SimCard kid = CardIds.NonCollectible.Neutral.MurlocTidehunter_MurlocScout;//murlocscout
//    kampfschrei:/ ruft einen murlocspäher (1/1) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own);
		}


	}
}