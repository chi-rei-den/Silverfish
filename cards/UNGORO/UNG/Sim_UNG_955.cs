using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_955",
  "name": [
    "陨石术",
    "Meteor"
  ],
  "text": [
    "对一个随从造成$15点伤害，并对其相邻的随从造成\n$3点伤害。",
    "Deal $15 damage to a minion and $3 damage to adjacent ones."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41878
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_955 : SimCard //* Meteor
	{
		//Deal $15 damage to a minion and $3 damage to adjacent ones.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmgMain = (ownplay) ? p.getSpellDamageDamage(15) : p.getEnemySpellDamageDamage(15);
            int dmgAdj = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            p.minionGetDamageOrHeal(target, dmgMain);
            foreach (Minion m in temp)
            {
                if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos) p.minionGetDamageOrHeal(m, dmgAdj);
            }
		}
	}
}