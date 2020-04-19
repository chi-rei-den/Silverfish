using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_063",
  "name": [
    "幽灵之爪",
    "Spirit Claws"
  ],
  "text": [
    "当你拥有<b>法术伤害</b>时，获得\n+2攻击力。",
    "[x]Has +2 Attack while you\nhave <b>Spell Damage</b>."
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 2,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39694
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_063 : SimTemplate //* Spirit Claws
	{
		//Has +2 Attack while you have Spell Damage.

        SimCard weapon = CardIds.Collectible.Shaman.SpiritClaws;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
            if (ownplay)
            {
                if (p.spellpower > 0)
                {
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownWeapon.Angr += 2;
                    p.ownSpiritclaws = true;
                }
            }
            else
            {
                if (p.enemyspellpower > 0)
                {
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                    p.enemyWeapon.Angr += 2;
                    p.enemySpiritclaws = true;
                }
            }
        }
	}
}