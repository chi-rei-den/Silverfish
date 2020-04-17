using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_275",
  "name": [
    "冰锥术",
    "Cone of Cold"
  ],
  "text": [
    "<b>冻结</b>一个随从和其相邻的随从，并对它们造成$1点伤害。",
    "<b>Freeze</b> a minion and the minions next to it, and deal $1 damage to them."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 430
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_275 : SimCard //* Cone of Cold
	{
        //Freeze a minion and the minions next to it, and deal $1 damage to them.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            p.minionGetFrozen(target);
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (target.zonepos == m.zonepos + 1 || target.zonepos + 1 == m.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                    p.minionGetFrozen(m);
                }
            }
		}
	}
}