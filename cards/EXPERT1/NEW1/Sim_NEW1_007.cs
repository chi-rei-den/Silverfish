using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_007",
  "name": [
    "星辰坠落",
    "Starfall"
  ],
  "text": [
    "<b>抉择：</b>对一个随从造成$5点伤害；或者对所有敌方随从造成$2点伤害。",
    "<b>Choose One -</b>\nDeal $5 damage to a minion; or $2 damage to all enemy minions."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 86
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_007 : SimCard //* Starfall
	{
        // Choose One - Deal $5 damage to a minion; or $2 damage to all enemy minions.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1 || (target != null && p.ownFandralStaghelm > 0 && ownplay))
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
                p.minionGetDamageOrHeal(target, dmg);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                p.allMinionOfASideGetDamage(!ownplay, damage);
            }
		}
	}
}