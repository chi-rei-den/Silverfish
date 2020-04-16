using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX9_07",
  "name": [
    "骑士印记",
    "Mark of the Horsemen"
  ],
  "text": [
    "使你的所有随从和武器获得+1/+1。",
    "Give your minions and your weapon +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1884
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX9_07 : SimTemplate //* Mark of the Horsemen
	{
		// Give your minions and your weapon +1/+1.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.allMinionOfASideGetBuffed(ownplay, 1, 1);
			
			if (ownplay)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Durability++;
                    p.ownWeapon.Angr++;
                    p.ownHero.Angr++;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Durability++;
                    p.enemyWeapon.Angr++;
                    p.enemyHero.Angr++;
                }
            }
		}
	}
}