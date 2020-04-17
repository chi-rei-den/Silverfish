using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_621",
  "name": [
    "治疗之环",
    "Circle of Healing"
  ],
  "text": [
    "为所有随从恢复#4点生命值。",
    "Restore #4 Health to ALL minions."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 0,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1362
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_621 : SimCard //circleofhealing
	{

//    stellt bei allen dienern #4 leben wieder her.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(4) : p.getEnemySpellHeal(4);
            p.allMinionsGetDamage(-heal);
		}

	}
}