using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_008",
  "name": [
    "知识古树",
    "Ancient of Lore"
  ],
  "text": [
    "<b>抉择：</b>抽一张牌；或者恢复#5点生命值。",
    "<b>Choose One -</b> Draw a card; or Restore #5 Health."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 7,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 920
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_008 : SimCard //* Ancient of Lore
    {
        //Choose One - Draw a card; or Restore 5 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 2 || (target != null && p.ownFandralStaghelm > 0 && own.own))
            {
                int heal = (own.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
                p.minionGetDamageOrHeal(target, -heal);
            }
            
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.drawACard(CardDB.cardIDEnum.None, own.own);
            }
        }
    }
}
