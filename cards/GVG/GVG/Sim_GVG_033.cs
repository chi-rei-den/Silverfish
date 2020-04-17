using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_033",
  "name": [
    "生命之树",
    "Tree of Life"
  ],
  "text": [
    "为所有角色恢复所有生命值。",
    "Restore all characters to full Health."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 9,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2001
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_033 : SimCard //* Tree of Life
    {

        //    Restore all characters to full Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			int heal = 1000;
            foreach (Minion m in p.ownMinions)
            {
                p.minionGetDamageOrHeal(m, -heal);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionGetDamageOrHeal(m, -heal);
            }

            p.minionGetDamageOrHeal(p.enemyHero, -heal);
            p.minionGetDamageOrHeal(p.ownHero, -heal);
        }


    }

}