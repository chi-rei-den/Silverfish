using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_078",
  "name": [
    "雪崩",
    "Avalanche"
  ],
  "text": [
    "<b>冻结</b>一个随从，并对其相邻的随从造成$3点伤害。",
    "<b>Freeze</b> a minion and deal $3 damage to adjacent ones."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42747
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_078: SimTemplate //* Avalanche
    {
        // Freeze a minion and deal 3 damage to Adjacent ones

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetFrozen(target);
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (target.zonepos == m.zonepos + 1 || target.zonepos + 1 == m.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }
    }
}