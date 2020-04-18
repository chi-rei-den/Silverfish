using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_089",
  "name": [
    "摇摆的俾格米",
    "Wobbling Runts"
  ],
  "text": [
    "<b>亡语：</b>召唤三个2/2的俾格米。",
    "<b>Deathrattle:</b> Summon three 2/2 Runts."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2961
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_089 : SimTemplate //* Wobbling Runts
	{
		//Deathrattle: Summon three 2/2 Runts.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(CardIds.NonCollectible.Neutral.WobblingRunts_RascallyRuntToken, m.zonepos - 1, m.own); //Rascally Runt
            p.callKid(CardIds.NonCollectible.Neutral.WobblingRunts_RascallyRuntToken2, m.zonepos, m.own); //Wily Runt
            p.callKid(CardIds.NonCollectible.Neutral.WobblingRunts_RascallyRuntToken3, m.zonepos + 1, m.own); //Grumbly Runt
        }
	}
}