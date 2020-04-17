using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_817",
  "name": [
    "海潮涌动",
    "Tidal Surge"
  ],
  "text": [
    "对一个随从造成$4点伤害。为你的英雄恢复#4点生命值。",
    "Deal $4 damage to a minion. Restore #4 Health to your hero."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41521
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_817 : SimCard //* Tidal Surge
	{
		//Deal $4 damage to a minion. Restore #4 Health to your hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            int heal = (ownplay) ? p.getSpellHeal(4) : p.getEnemySpellHeal(4);
			
            if (target != null) p.minionGetDamageOrHeal(target, dmg);
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }
    }
}