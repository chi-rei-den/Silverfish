using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_055",
  "name": [
    "废旧螺栓机甲",
    "Screwjank Clunker"
  ],
  "text": [
    "<b>战吼：</b>使一个友方机械获得+2/+2。",
    "<b>Battlecry:</b> Give a friendly Mech +2/+2."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2023
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_055 : SimCard //Screwjank Clunker
    {

        //   Battlecry&lt;/b&gt;: Give a friendly Mech +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if (target == null) return;
            p.minionGetBuffed(target, 2, 2);
        }


    }

}