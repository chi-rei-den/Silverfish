using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_309",
  "name": [
    "哈霍兰公主",
    "Princess Huhuran"
  ],
  "text": [
    "<b>战吼：</b>触发一个友方随从的<b>亡语</b>。",
    "<b>Battlecry:</b> Trigger a friendly minion's <b>Deathrattle</b>."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38910
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_309 : SimTemplate //* Princess Huhuran
    {
        //Battlecry: Trigger a friendly minion's Deathrattle effect immediately.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.doDeathrattles(new List<Minion>() { target });
        }
    }
}