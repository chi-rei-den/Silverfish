using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_081",
  "name": [
    "冰爆",
    "Shatter"
  ],
  "text": [
    "消灭一个被<b>冻结</b>的随从。",
    "Destroy a <b>Frozen</b> minion."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38407
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_081 : SimCard //* Shatter
	{
		//Destroy a Frozen minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			if (target != null) p.minionGetDestroyed(target);
        }
    }
}