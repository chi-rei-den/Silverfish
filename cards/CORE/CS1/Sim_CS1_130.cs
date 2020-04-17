using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS1_130",
  "name": [
    "神圣惩击",
    "Holy Smite"
  ],
  "text": [
    "对一个随从造成$3点伤害。",
    "Deal $3 damage\nto a minion."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 279
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS1_130 : SimCard //holysmite
	{

//    verursacht $2 schaden.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}