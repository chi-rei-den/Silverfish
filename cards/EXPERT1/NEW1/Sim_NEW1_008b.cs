using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_008b",
  "name": [
    "古老的秘密",
    "Ancient Secrets"
  ],
  "text": [
    "恢复5点生命值。",
    "Restore 5 Health."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 209
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_008b : SimCard //* Ancient Secrets
	{
		//Restore 5 Health.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            p.minionGetDamageOrHeal(target, -heal);
		}
	}
}