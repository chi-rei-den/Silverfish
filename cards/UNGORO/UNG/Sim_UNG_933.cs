using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_933",
  "name": [
    "暴龙之王摩什",
    "King Mosh"
  ],
  "text": [
    "<b>战吼：</b>消灭所有受伤的随从。",
    "<b>Battlecry:</b> Destroy all damaged minions."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41425
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_933 : SimTemplate //* King Mosh
	{
		//Battlecry: Destroy all damaged minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                if (m.wounded)  p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.wounded) p.minionGetDestroyed(m);
            }
        }
    }
}