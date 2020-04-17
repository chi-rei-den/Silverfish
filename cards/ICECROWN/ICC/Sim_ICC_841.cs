using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_841",
  "name": [
    "鲜血女王兰娜瑟尔",
    "Blood-Queen Lana'thel"
  ],
  "text": [
    "<b>吸血</b>\n在本局对战中，你每弃掉一张牌，便获得+1攻击力。",
    "[x]<b>Lifesteal</b>\nHas +1 Attack for each\ncard you've discarded\nthis game."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43064
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_841 : SimCard //* Blood-Queen Lana'thel
    {
        // Lifesteal. Has +1 Attack for each card you've discarded this game.
        //Only on the board

        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (own == null) return false;
            if (checkBonus) return false;

            p.minionGetBuffed(own, num, 0);
            return false;
        }
    }
}