using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_108",
  "name": [
    "侏儒变形师",
    "Recombobulator"
  ],
  "text": [
    "<b>战吼：</b>\n将一个友方随从随机变形成为一个法力值消耗相同的随从。",
    "<b>Battlecry:</b> Transform a friendly minion into a random minion with the same Cost."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2076
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_108 : SimCard //Recombobulator
    {

        //   Battlecry: Transform a friendly minion into a random minion with the same Cost.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if(target == null) return;
            p.minionTransform(target, target.handcard.card);
        }

    }

}