using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_093",
  "name": [
    "奉献",
    "Consecration"
  ],
  "text": [
    "对所有敌人造成$2点伤害。",
    "Deal $2 damage to all enemies."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 476
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_093 : SimTemplate //consecration
	{

//    fügt allen feinden $2 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allCharsOfASideGetDamage(!ownplay, dmg);
		}

	}
}