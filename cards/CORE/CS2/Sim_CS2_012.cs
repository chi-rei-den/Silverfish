using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_012",
  "name": [
    "横扫",
    "Swipe"
  ],
  "text": [
    "对一个敌人造成$4点伤害，并对所有其他敌人\n造成$1点伤害。",
    "Deal $4 damage to an enemy and $1 damage to all other enemies."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 64
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_012 : SimTemplate // Swipe
	{
        // Deal $4 damage to an enemy and $1 damage to all other enemies.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            int dmg1 = (ownplay)? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);

            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            p.minionGetDamageOrHeal(target, dmg);
            foreach (Minion m in temp)
            {
                if (m.entitiyID != target.entitiyID)
                {
                    m.getDamageOrHeal(dmg1, p, true, false); // isMinionAttack=true because it is extra damage (we calc clear lostDamage)
                }
            }
            if (ownplay)
            {
                if (p.enemyHero.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(p.enemyHero, dmg1);
                }
                if (Hrtprozis.Instance.enemyMinions.Count > p.enemyMinions.Count) p.lostDamage += dmg1;
            }
            else
            {
                if (p.ownHero.entitiyID != target.entitiyID)
                {
                    p.minionGetDamageOrHeal(p.ownHero, dmg1);
                }
                if (Hrtprozis.Instance.ownMinions.Count > p.ownMinions.Count) p.lostDamage += dmg1;
            }
		}
	}
}