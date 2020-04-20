using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_050",
  "name": [
    "弹射之刃",
    "Bouncing Blade"
  ],
  "text": [
    "随机对一个随从造成$1点伤害。重复此效果，直到某个随从死亡。",
    "Deal $1 damage to a random minion. Repeat until a minion dies."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2018
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_050 : SimTemplate //Bouncing Blade
    {

        //   Deal $1 damage to a random minion. Repeat until a minion dies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);

            int minHp = 100000;
            foreach (Minion m in p.ownMinions)
            {
                if (m.Hp < minHp) minHp = m.Hp;
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Hp < minHp) minHp = m.Hp;
            }

            int dmgdone = (int)Math.Ceiling(minHp / (double)dmg) * dmg;

            p.allMinionsGetDamage(dmgdone);
        }


    }

}