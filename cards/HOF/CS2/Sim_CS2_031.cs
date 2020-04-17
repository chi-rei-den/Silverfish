using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_031",
  "name": [
    "冰枪术",
    "Ice Lance"
  ],
  "text": [
    "使一个角色<b>冻结</b>，如果它已经被<b>冻结</b>，则改为对其造成$4点伤害。",
    "<b>Freeze</b> a character. If it was already <b>Frozen</b>, deal $4 damage instead."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 172
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_031 : SimCard //* Ice Lance
	{
        //Freeze a character. If it was already Frozen, deal $4 damage instead.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            
            if (target.frozen)
            {
                p.minionGetDamageOrHeal(target, dmg);
            }
            else
            {
                p.minionGetFrozen(target);
            }
		}
	}
}