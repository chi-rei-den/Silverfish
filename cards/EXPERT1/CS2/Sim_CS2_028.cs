using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_028",
  "name": [
    "暴风雪",
    "Blizzard"
  ],
  "text": [
    "对所有敌方随从造成$2点伤害，并使其<b>冻结</b>。",
    "Deal $2 damage to all enemy minions and <b>Freeze</b> them."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 457
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_028 : SimTemplate //* blizzard
	{
        //Deal 2 damage to all enemy minions and Freeze them.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg, true);
			List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            foreach (Minion t in temp)
            {
                p.minionGetFrozen(t);
            }
		}
	}
}