using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_312",
  "name": [
    "扭曲虚空",
    "Twisting Nether"
  ],
  "text": [
    "消灭所有随从。",
    "Destroy all minions."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 8,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 859
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_312 : SimCard //twistingnether
	{

//    vernichtet alle diener.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.allMinionsGetDestroyed();
		}

	}
}