using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_923",
  "name": [
    "铜皮铁甲",
    "Iron Hide"
  ],
  "text": [
    "获得5点护甲值。",
    "Gain 5 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41401
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_923 : SimCard //* Iron Hide
	{
		//Gain 5 Armor.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 5);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 5);
            }
		}

	}
}