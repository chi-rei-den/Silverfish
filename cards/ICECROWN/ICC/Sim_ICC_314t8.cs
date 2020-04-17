using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t8",
  "name": [
    "死亡凋零",
    "Death and Decay"
  ],
  "text": [
    "对所有敌人造成$3点伤害。",
    "Deal $3 damage to all enemies."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 46194
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t8 : SimCard //* Death and Decay
    {
        // Deal $3 damage to all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allCharsOfASideGetDamage(!ownplay, dmg);
        }
    }
}