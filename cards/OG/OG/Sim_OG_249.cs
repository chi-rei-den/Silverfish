using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_249",
  "name": [
    "被感染的牛头人",
    "Infested Tauren"
  ],
  "text": [
    "<b>嘲讽</b>\n<b>亡语：</b>召唤一个2/2的泥浆怪。",
    "<b>Taunt</b>\n<b>Deathrattle:</b> Summon a 2/2 Slime."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38784
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_249 : SimTemplate //* Infested Tauren
	{
		//Taunt. Deathrattle: Summon a 2/2 Slime.
		
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.FalloutSlime;
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
        }
	}
}