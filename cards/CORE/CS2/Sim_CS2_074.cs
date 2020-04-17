using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_074",
  "name": [
    "致命药膏",
    "Deadly Poison"
  ],
  "text": [
    "使你的武器获得+2攻击力。",
    "Give your weapon +2 Attack."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 459
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_074 : SimCard //deadlypoison
	{

//    eure waffe erhält +2 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 2;
                    p.ownHero.Angr += 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.enemyHero.Angr += 2;
                }
            }
		}

	}
}