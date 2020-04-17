using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_052",
  "name": [
    "装死",
    "Play Dead"
  ],
  "text": [
    "触发一个友方随从的<b>亡语</b>。",
    "Trigger a friendly minion's <b>Deathrattle</b>."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42652
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_052: SimCard //* Play Dead
    {
        // Triger a friendly minion's deathrattle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.doDeathrattles(new List<Minion>() { target });
        }
    }
}