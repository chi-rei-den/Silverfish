using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_030b",
  "name": [
    "坦克模式",
    "Tank Mode"
  ],
  "text": [
    "+1生命值。",
    "+1 Health."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2197
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_030b : SimTemplate //Tank Mode
	{

        //   +1 Health.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetBuffed(own, 0, 1);
		}


	}
}