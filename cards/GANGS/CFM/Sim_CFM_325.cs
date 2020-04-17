using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_325",
  "name": [
    "蹩脚海盗",
    "Small-Time Buccaneer"
  ],
  "text": [
    "如果你装备一把武器，该随从具有\n+2攻击力。",
    "Has +2 Attack while you have a weapon equipped."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40608
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_325 : SimCard //* Small-time Buccaneer
	{
		// Has +2 Attack while you have a weapon equipped.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability > 0) p.minionGetBuffed(m, 2, 0);
            }
            else
            {
                if (p.enemyWeapon.Durability > 0) p.minionGetBuffed(m, 2, 0);
            }
        }
    }
}