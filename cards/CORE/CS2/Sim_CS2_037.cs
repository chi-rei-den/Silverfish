using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_037",
  "name": [
    "冰霜震击",
    "Frost Shock"
  ],
  "text": [
    "对一个敌方角色造成$1点伤害，并使其<b>冻结</b>。",
    "Deal $1 damage to an enemy character and <b>Freeze</b> it."
  ],
  "CardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 971
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_037 : SimTemplate //* Frost Shock
	{
        //Deal $1 damage to an enemy character and Freeze it.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetFrozen(target);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}