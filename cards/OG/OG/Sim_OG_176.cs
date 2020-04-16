using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_176",
  "name": [
    "暗影打击",
    "Shadow Strike"
  ],
  "text": [
    "对一个\n未受伤的角色造成$5点伤害。",
    "Deal $5 damage to an undamaged character."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38578
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_176 : SimTemplate //* Shadow Strike
	{
		//Deal 5 damage to an undamaged character.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}