using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_467",
  "name": [
    "亡语者",
    "Deathspeaker"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，使一个友方随从获得<b>免疫</b>。",
    "<b>Battlecry:</b> Give a friendly minion <b>Immune</b> this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42394
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_467: SimCard //* Deathspeaker
    {
        // Battlecry: Give a friendly minion Immune this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) target.immune = true;
        }
    }
}