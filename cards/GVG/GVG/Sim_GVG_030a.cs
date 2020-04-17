using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_030a",
  "name": [
    "攻击模式",
    "Attack Mode"
  ],
  "text": [
    "+1攻击力。",
    "+1 Attack."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2195
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_030a : SimCard //Attack Mode
	{

        //    +1 Attack.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetBuffed(own, 1, 0);
		}



	}
}