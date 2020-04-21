using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_336",
  "name": [
    "豺狼人土枪手",
    "Shaky Zipgunner"
  ],
  "text": [
    "<b>亡语：</b>随机使你手牌中的一张随从牌获得+2/+2。",
    "[x]<b>Deathrattle:</b> Give a random\nminion in your hand +2/+2."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40681
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_336 : SimTemplate //* Shaky Zipgunner
	{
		// Deathrattle: Give a random minion in your hand +2/+2.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                Handcard hc = p.searchRandomMinionInHand(p.owncards, SearchMode.LowCost);
                if (hc != null)
                {
                    hc.addattack += 2;
                    hc.addHp += 2;
                    p.anzOwnExtraAngrHp += 4;
                }
            }
        }
	}
}