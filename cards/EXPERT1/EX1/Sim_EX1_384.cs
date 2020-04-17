using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_384",
  "name": [
    "复仇之怒",
    "Avenging Wrath"
  ],
  "text": [
    "造成$8点伤害，随机分配到所有敌人身上。",
    "Deal $8 damage randomly split among all enemies."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1174
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_384 : SimCard //* avengingwrath
    {
        //Deal $8 damage randomly split among all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}