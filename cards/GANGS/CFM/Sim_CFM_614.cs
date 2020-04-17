using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_614",
  "name": [
    "玉莲印记",
    "Mark of the Lotus"
  ],
  "text": [
    "使你所有的随从获得+1/+1。",
    "Give your minions +1/+1."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40397
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_614 : SimCard //* Mark of the Lotus
	{
		// Give your minions +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 1, 1);
        }
    }
}