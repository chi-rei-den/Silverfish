using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_085",
  "name": [
    "翡翠蜂后",
    "Emerald Hive Queen"
  ],
  "text": [
    "你的随从的法力值消耗增加（2）点。",
    "Your minions cost (2) more."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41261
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_085 : SimCard //* Emerald Hive Queen
	{
		//Your minions cost (2) more.

        public override void onAuraStarts(Playfield p, Minion own)
		{
           if(own.own) p.ownMinionsCostMore += 2;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
           if(own.own) p.ownMinionsCostMore -= 2;
        }
	}
}