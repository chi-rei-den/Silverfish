using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_836",
  "name": [
    "冰龙吐息",
    "Breath of Sindragosa"
  ],
  "text": [
    "随机对一个敌方随从造成$2点伤害，并使其<b>冻结</b>。",
    "Deal $2 damage to a random enemy minion and <b>Freeze</b> it."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43502
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_836: SimCard //* Breath of Sindragosa
    {
        // Deal 2 damage to a random enemy minion and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            target = null;
            if (ownplay)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg, true);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
            }
            if (target != null)
            {
                p.minionGetDamageOrHeal(target, dmg);
                p.minionGetFrozen(target);
            }
        }
    }
}