using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_537",
  "name": [
    "爆炸射击",
    "Explosive Shot"
  ],
  "text": [
    "对一个随从造成$5点伤害，并对其相邻的随从造成\n$2点伤害。",
    "Deal $5 damage to a minion and $2 damage to adjacent ones."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 394
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_537 : SimCard // Explosive Shot
	{
        // Deal $5 damage to a minion and $2 damage to adjacent ones.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            int dmg1 = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            p.minionGetDamageOrHeal(target, dmg);
            foreach (Minion m in temp)
            {
                if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos) m.getDamageOrHeal(dmg1, p, true, false); // isMinionAttack=true because it is extra damage (we calc clear lostDamage)
            }
		}
	}
}