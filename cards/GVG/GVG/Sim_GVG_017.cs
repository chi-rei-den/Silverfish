using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_017",
  "name": [
    "召唤宠物",
    "Call Pet"
  ],
  "text": [
    "抽一张牌。如果该牌是野兽牌，则其法力值消耗\n减少（4）点。",
    "Draw a card.\nIf it's a Beast, it costs (4) less."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2094
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_017 : SimTemplate //* Call Pet
    {

        //    Draw a card. If it's a Beast, it costs (4) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
        }
    }
}