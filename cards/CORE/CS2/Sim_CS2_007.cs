using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_007",
  "name": [
    "治疗之触",
    "Healing Touch"
  ],
  "text": [
    "恢复#8点生命值。",
    "Restore #8 Health."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 773
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_007 : SimTemplate //healingtouch
	{

//    stellt #8 leben wieder her.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(8) : p.getEnemySpellHeal(8);
            p.minionGetDamageOrHeal(target, -heal);
            
		}

	}
}