using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_021",
  "name": [
    "小鬼骑士",
    "Tiny Knight of Evil"
  ],
  "text": [
    "每当你弃掉一张牌时，便获得+1/+1。",
    "Whenever you discard a card, gain +1/+1."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2777
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_021 : SimCard //* Tiny Knight of Evil
	{
        //Whenever you discard a card, gain +1/+1.
        //Only on the board
        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (own == null) return false;
            if (checkBonus) return false;

            p.minionGetBuffed(own, num, num);
            return false;
        }
    }
}