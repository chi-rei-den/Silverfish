using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_100",
  "name": [
    "暗言术：骇",
    "Shadow Word: Horror"
  ],
  "text": [
    "消灭所有攻击力小于或等于2的随从。",
    "Destroy all minions with 2 or less Attack."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38433
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_100 : SimCard //* Shadow Word: Horror
    {
        //Destroy all minions with 2 or less Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Angr < 3) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if (m.Angr < 3) p.minionGetDestroyed(m);
            }
        }
    }
}