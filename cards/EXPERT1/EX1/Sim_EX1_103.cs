using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_103",
  "name": [
    "寒光先知",
    "Coldlight Seer"
  ],
  "text": [
    "<b>战吼：</b>使你的其他鱼人获得+2生命值。",
    "<b>Battlecry:</b> Give your other Murlocs +2 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 453
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_103 : SimTemplate//* Coldlight Seer
    {
        // Battlecry: Give your other Murlocs +2 Health.
	
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((Race)m.handcard.card.Race == Race.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 0, 2);
            }
        }
    }
}
