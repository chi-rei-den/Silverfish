using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_084",
  "name": [
    "猎人印记",
    "Hunter's Mark"
  ],
  "text": [
    "使一个随从的生命值变为1。",
    "Change a minion's Health to 1."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 141
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_084 : SimTemplate //* huntersmark
	{
        //Change a minion's Health to 1.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionSetLifetoX(target, 1);
		}

	}
}