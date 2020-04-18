using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_409",
  "name": [
    "升级",
    "Upgrade!"
  ],
  "text": [
    "如果你装备一把武器，使它获得+1/+1。否则，装备一把1/3的武器。",
    "If you have a weapon, give it +1/+1. Otherwise equip a 1/3 weapon."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 511
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_409 : SimTemplate //* Upgrade!
	{
        // If you have a weapon, give it +1/+1. Otherwise equip a 1/3 weapon.

        Chireiden.Silverfish.SimCard wcard = CardIds.NonCollectible.Warrior.Upgrade_HeavyAxeToken;//Heavy Axe

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownWeapon.Durability > 0)
                {
                    p.ownWeapon.Angr++;
                    p.ownWeapon.Durability++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
                else
                {
                    p.equipWeapon(wcard, true);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability > 0)
                {
                    p.enemyWeapon.Angr++;
                    p.enemyWeapon.Durability++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
                else
                {
                    p.equipWeapon(wcard, false);
                }
            }
		}
	}
}