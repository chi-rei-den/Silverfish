using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_083b",
  "name": [
    "匕首精通",
    "Dagger Mastery"
  ],
  "text": [
    "<b>英雄技能</b>\n装备一把1/2的\n匕首。",
    "<b>Hero Power</b>\nEquip a 1/2 Dagger."
  ],
  "CardClass": "ROGUE",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 730
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_083b : SimTemplate //daggermastery
	{

//    heldenfähigkeit/\nlegt einen dolch (1/2) an.
        SimCard weapon = CardIds.NonCollectible.Rogue.WickedKnife;
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

	}
}