using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_008",
  "name": [
    "圣光炸弹",
    "Lightbomb"
  ],
  "text": [
    "对所有随从造成等同于其攻击力的伤害。",
    "Deal damage to each minion equal to its Attack."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1938
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_008 : SimCard //Lightbomb
    {

        //    Deal damage to each minion equal to its Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                p.minionGetDamageOrHeal(m, m.Angr, true);
            }

            foreach (Minion m in p.enemyMinions)
            {
                p.minionGetDamageOrHeal(m, m.Angr, true);
            }
        }


    }

}