using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_ROGUE",
  "name": [
    "浸毒匕首",
    "Poisoned Daggers"
  ],
  "text": [
    "<b>英雄技能</b>\n装备一把2/2的\n匕首。",
    "<b>Hero Power</b>\nEquip a 2/2 Weapon."
  ],
  "cardClass": "ROGUE",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2743
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_ROGUE : SimTemplate //* Poisoned Daggers
	{
		//Hero Power. Equip a 2/2 Weapon.

        SimCard weapon = CardIds.NonCollectible.Rogue.JusticarTrueheart_PoisonedDagger;
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}