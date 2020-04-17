using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_029",
  "name": [
    "雷德·黑手",
    "Rend Blackhand"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，则消灭一个<b>传说</b>随从。",
    "<b>Battlecry:</b> If you're holding a Dragon, destroy a <b>Legendary</b> minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2308
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_029 : SimCard //* Rend Blackhand
    {
        // Battlecry: If you're holding a Dragon, destroy a Legendary minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDestroyed(target);
        }
    }
}