using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_277",
  "name": [
    "奥术飞弹",
    "Arcane Missiles"
  ],
  "text": [
    "造成$3点伤害，随机分配到所有敌人身上。",
    "Deal $3 damage randomly split among all enemies."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 564
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_277 : SimTemplate //* Arcane Missiles
    {
        
        //Deal $3 damage randomly split among all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}