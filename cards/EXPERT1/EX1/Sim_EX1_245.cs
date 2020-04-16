using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_245",
  "name": [
    "大地震击",
    "Earth Shock"
  ],
  "text": [
    "<b>沉默</b>一个随从，然后对其造成$1点伤害。",
    "<b>Silence</b> a minion, then deal $1 damage to it."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 767
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_245 : SimTemplate //earthshock
	{

//    bringt einen diener zum schweigen/ und fügt ihm dann $1 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}