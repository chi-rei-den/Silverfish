using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_702",
  "name": [
    "孱弱的掘墓者",
    "Shallow Gravedigger"
  ],
  "text": [
    "<b>亡语：</b>随机将一个具有<b>亡语</b>的随从置入你的手牌。",
    "<b>Deathrattle:</b> Add a random <b>Deathrattle</b> minion to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42785
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_702: SimTemplate //* Shallow Gravedigger
    {
        // Deathrattle: Add a random Deathrattle minion to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, m.own, true);
        }
    }
}