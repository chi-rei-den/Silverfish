using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_313",
  "name": [
    "腐化灰熊",
    "Addled Grizzly"
  ],
  "text": [
    "在你召唤一个随从后，使其获得+1/+1。",
    "After you summon a minion, give it +1/+1."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38916
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_313 : SimCard //* Addled Grizzly
	{
		//After you summon a minion, give it +1/+1.
		
		public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
			if (m.own == summonedMinion.own && m.entitiyID != summonedMinion.entitiyID)
			{
				p.minionGetBuffed(summonedMinion, 1, 1);
			}
        }
	}
}