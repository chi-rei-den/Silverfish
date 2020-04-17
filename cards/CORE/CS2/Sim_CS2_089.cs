using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_089",
  "name": [
    "圣光术",
    "Holy Light"
  ],
  "text": [
    "恢复#6点生命值。",
    "Restore #6 Health."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 291
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_089 : SimCard //holylight
	{

//    stellt #6 leben wieder her.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(6) : p.getEnemySpellHeal(6);
            p.minionGetDamageOrHeal(target, -heal);
		}

	}
}