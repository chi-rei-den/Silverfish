using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_019",
  "name": [
    "恐惧战马",
    "Dreadsteed"
  ],
  "text": [
    "<b>亡语：</b>\n在回合结束时，召唤一匹恐惧战马。",
    "<b>Deathrattle:</b> At the end\n of the turn, summon a Dreadsteed."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2822
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_019 : SimTemplate //* Dreadsteed
	{
		//Deathrattle: Summon a Dreadsteed.

        SimCard kid = CardIds.Collectible.Warlock.Dreadsteed;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
        }
	}
}