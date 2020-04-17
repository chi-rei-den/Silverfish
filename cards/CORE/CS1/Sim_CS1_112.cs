using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS1_112",
  "name": [
    "神圣新星",
    "Holy Nova"
  ],
  "text": [
    "对所有敌方随从造成$2点伤害，为所有友方角色恢复#2点\n生命值。",
    "Deal $2 damage to all enemy minions. Restore #2 Health to all friendly characters."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 841
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS1_112 : SimCard//holy nova
    {
        //todo make it better :D
        //FÃ¼gt allen Feinden $2 Schaden zu. Stellt bei allen befreundeten Charakteren #2 Leben wieder her.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay)? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            int heal = (ownplay) ? p.getSpellHeal(2) : p.getEnemySpellHeal(2) ;
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.ownHero, -heal);
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
                foreach (Minion m in p.ownMinions)
                {
                    p.minionGetDamageOrHeal(m, -heal);
                }

                foreach (Minion m in p.enemyMinions)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
            else 
            {
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
                p.minionGetDamageOrHeal(p.ownHero, dmg);
                foreach (Minion m in p.enemyMinions)
                {
                    p.minionGetDamageOrHeal(m, -heal);
                }

                foreach (Minion m in p.ownMinions)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }

    }
}
