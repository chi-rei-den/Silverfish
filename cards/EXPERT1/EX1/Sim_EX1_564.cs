using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_564",
  "name": [
    "无面操纵者",
    "Faceless Manipulator"
  ],
  "text": [
    "<b>战吼：</b>选择一个随从，成为它的复制。",
    "<b>Battlecry:</b> Choose a minion and become a copy of it."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 531
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_564 : SimTemplate //facelessmanipulator
    {

        //    kampfschrei:/ wählt einen diener aus, um gesichtsloser manipulator in eine kopie desselben zu verwandeln.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                //p.copyMinion(own, target);
                bool source = own.own;
                own.setMinionToMinion(target);
                own.own = source;
                own.handcard.card.sim_card.onAuraStarts(p, own);
            }
        }


    }
}