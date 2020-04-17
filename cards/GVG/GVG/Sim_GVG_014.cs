using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_014",
  "name": [
    "沃金",
    "Vol'jin"
  ],
  "text": [
    "<b>战吼：</b>与另一个随从交换生命值。",
    "<b>Battlecry:</b> Swap Health with another minion."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1931
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_014 : SimCard //* Vol'jin
    {
       //Battlecry: Swap Health with another minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            own.maxHp = target.Hp;
            target.maxHp = own.Hp;

            own.Hp = own.maxHp;
            target.Hp = target.maxHp;
            if (target.wounded)
            {
                target.wounded = false;
                target.handcard.card.sim_card.onEnrageStop(p, target);
            }
        }
    }
}