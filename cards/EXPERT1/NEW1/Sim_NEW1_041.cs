using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_041",
  "name": [
    "狂奔科多兽",
    "Stampeding Kodo"
  ],
  "text": [
    "<b>战吼：</b>随机消灭一个攻击力小于或等于2的敌方随从。",
    "<b>Battlecry:</b> Destroy a random enemy minion with 2 or less Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1371
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_041 : SimCard //Stampeding Kodo
    {
        //Battlecry: Destroy a random enemy minion with 2 or less Attack.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp2 = (own.own) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));//destroys the weakest
            foreach (Minion enemy in temp2)
            {
                if (enemy.Angr <= 2)
                {
                    p.minionGetDestroyed(enemy);
                    break;
                }
            }
        }
    }
}
