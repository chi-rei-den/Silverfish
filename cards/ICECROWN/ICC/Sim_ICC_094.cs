using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_094",
  "name": [
    "堕落残阳祭司",
    "Fallen Sun Cleric"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+1/+1。",
    "<b>Battlecry:</b> Give a friendly minion +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42777
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_094: SimCard //* Fallen Sun Cleric
    {
        // Battlecry: Give a friendly minion +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}