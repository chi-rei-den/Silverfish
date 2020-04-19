using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_072",
  "name": [
    "背刺",
    "Backstab"
  ],
  "text": [
    "对一个未受伤的随从造成$2点\n伤害。",
    "Deal $2 damage to an undamaged minion."
  ],
  "CardClass": "ROGUE",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 180
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_072 : SimTemplate //backstab
	{

//    fügt einem unverletzten diener $2 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}