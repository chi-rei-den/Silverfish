using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_010",
  "name": [
    "臃肿的蛇颈龙",
    "Sated Threshadon"
  ],
  "text": [
    "<b>亡语：</b>召唤三个1/1的鱼人。",
    "<b>Deathrattle:</b> Summon three 1/1 Murlocs."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41138
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_010 : SimTemplate //* Sated Threshadon
	{
		//Deathrattle: Summon three 1/1 Murlocs.

        SimCard kid = CardIds.NonCollectible.Neutral.PrimalfinTotem_PrimalfinToken; //Primalfin
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos-1, m.own);
            p.callKid(kid, m.zonepos-1, m.own);
            p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}