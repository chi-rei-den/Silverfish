using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_201",
  "name": [
    "命运骨骰",
    "Roll the Bones"
  ],
  "text": [
    "抽一张牌。如果这张牌具有<b>亡语</b>，则再次施放该法术。",
    "Draw a card.\nIf it has <b>Deathrattle</b>, cast this again."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42560
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_201: SimTemplate //* Roll the Bones
    {
        // Draw a card. If it has Deathrattle, cast this again.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
        }
    }
}