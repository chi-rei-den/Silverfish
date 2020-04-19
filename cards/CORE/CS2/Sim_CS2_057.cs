using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_057",
  "name": [
    "暗影箭",
    "Shadow Bolt"
  ],
  "text": [
    "对一个随从造成$4点伤害。",
    "Deal $4 damage\nto a minion."
  ],
  "CardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 914
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_057 : SimTemplate //shadowbolt
	{

//    fügt einem diener $4 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}