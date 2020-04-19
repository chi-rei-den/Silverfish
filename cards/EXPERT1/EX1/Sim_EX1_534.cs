using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_534",
  "name": [
    "长鬃草原狮",
    "Savannah Highmane"
  ],
  "text": [
    "<b>亡语：</b>召唤两只2/2的土狼。",
    "<b>Deathrattle:</b> Summon two 2/2 Hyenas."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1261
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_534 : SimTemplate //* savannahhighmane
	{
        //Deathrattle: Summon two 2/2 Hyenas.

        Chireiden.Silverfish.SimCard c = CardIds.NonCollectible.Hunter.SavannahHighmane_HyenaToken;//hyena
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(c, m.zonepos-1, m.own);
            p.callKid(c, m.zonepos-1, m.own);
        }
	}
}