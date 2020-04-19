using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_076",
  "name": [
    "卑劣的窃蛋者",
    "Eggnapper"
  ],
  "text": [
    "<b>亡语：</b>召唤两个1/1的迅猛龙。",
    "<b>Deathrattle:</b> Summon two 1/1 Raptors."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41249
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_076 : SimTemplate //* Eggnapper
	{
		//Deathrattle: Summon two 1/1 Raptors.

        SimCard kid = CardIds.NonCollectible.Neutral.Eggnapper_RaptorToken; //1/1 Raptor
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos-1, m.own);
            p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}