using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_024",
  "name": [
    "绿皮船长",
    "Captain Greenskin"
  ],
  "text": [
    "<b>战吼：</b>使你的武器获得+1/+1。",
    "<b>Battlecry:</b> Give your weapon +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 456
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_024 : SimTemplate //captaingreenskin
	{
//    kampfschrei:/ verleiht eurer waffe +1/+1.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Durability++;
                    p.ownWeapon.Angr++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Durability++;
                    p.enemyWeapon.Angr++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
            }
		}

	}
}