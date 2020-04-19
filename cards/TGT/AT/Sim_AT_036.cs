using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_036",
  "name": [
    "阿努巴拉克",
    "Anub'arak"
  ],
  "text": [
    "<b>亡语：</b>将该随从移回你的手牌，召唤一个4/4的蛛魔。",
    "<b>Deathrattle:</b> Return this to your hand and summon a 4/4 Nerubian."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2586
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_036 : SimTemplate //* Anub'arak
	{
		//Deathrattle: Return this to your hand and summon a 4/4 Nerubian.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.NerubianEgg_NerubianToken;//Nerubian

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.minionReturnToHand(m, m.own, 0);
            p.callKid(kid, m.zonepos - 1, m.own);		
        }
	}
}