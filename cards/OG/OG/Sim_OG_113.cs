using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_113",
  "name": [
    "夜色镇议员",
    "Darkshire Councilman"
  ],
  "text": [
    "在你召唤一个随从后，获得+1攻击力。",
    "[x]After you summon a minion,\n gain +1 Attack."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38452
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_113 : SimTemplate //* Darkshire Councilman
	{
		//After you summon a minion, gain +1 Attack.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
				p.minionGetBuffed(m, 1, 0);
            }
        }
    }
}