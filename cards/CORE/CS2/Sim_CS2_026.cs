using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_026",
  "name": [
    "冰霜新星",
    "Frost Nova"
  ],
  "text": [
    "<b>冻结</b>所有敌方随从。",
    "<b>Freeze</b> all enemy minions."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 587
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_026 : SimCard //* Frost Nova
    {
        // Freeze all enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            foreach (Minion t in temp)
            {
                p.minionGetFrozen(t);
            }
        }
    }
}