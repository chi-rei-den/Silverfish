using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_099",
  "name": [
    "榴弹投手",
    "Bomb Lobber"
  ],
  "text": [
    "<b>战吼：</b>随机对一个敌方随从造成4点伤害。",
    "<b>Battlecry:</b> Deal 4 damage to a random enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2067
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_099 : SimCard //Bomb Lobber
    {

        // Battlecry: Deal 4 damage to a random enemy minion.  

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.enemyMinions : p.ownMinions;
            int times = (own.own) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            if (temp.Count >= 1)
            {
                //search Minion with lowest hp
                Minion enemy = temp[0];
                int minhp = 10000;
                foreach (Minion m in temp)
                {
                    if (m.Hp >= times + 1 && minhp > m.Hp)
                    {
                        enemy = m;
                        minhp = m.Hp;
                    }
                }

                p.minionGetDamageOrHeal(enemy, times);

            } 
        }

    }

}