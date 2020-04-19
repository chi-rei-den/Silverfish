using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_216",
  "name": [
    "寄生恶狼",
    "Infested Wolf"
  ],
  "text": [
    "<b>亡语：</b>召唤两只1/1的蜘蛛。",
    "<b>Deathrattle:</b> Summon two 1/1 Spiders."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38734
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_216 : SimTemplate //* Infested Wolf
	{
		//Deathrattle: Summon two 1/1 Spiders.

        SimCard kid = CardIds.NonCollectible.Hunter.InfestedWolf_Spider;
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos-1, m.own);
            p.callKid(kid, m.zonepos-1, m.own);
        }
	}
}