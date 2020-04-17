using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_014",
  "name": [
    "熔火怒犬",
    "Core Rager"
  ],
  "text": [
    "<b>战吼：</b>如果你没有其他手牌，则获得+3/+3。",
    "<b>Battlecry:</b> If your hand is empty, gain +3/+3."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2263
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_014 : SimCard //* Core Rager
    {
        // Battlecry: If your hand is empty, gain +3/+3.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int cardsCount = (m.own) ? p.owncards.Count : p.enemyAnzCards;
            if (cardsCount <= 0)
            {
                p.minionGetBuffed(m, 3, 3);
            }
        }
    }
}