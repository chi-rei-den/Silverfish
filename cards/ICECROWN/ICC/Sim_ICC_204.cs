using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_204",
  "name": [
    "普崔塞德教授",
    "Professor Putricide"
  ],
  "text": [
    "在你使用一个<b>奥秘</b>后，随机将一个猎人的<b>奥秘</b>置入战场。",
    "After you play a <b>Secret</b>,\nput a random Hunter <b>Secret</b> into the battlefield."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42563
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_204 : SimTemplate //* Professor Putricide
    {
        // After you play a Secret, put another random Hunter secret into play.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (hc.card.Secret) p.evaluatePenality -= 9;
        }

    }
}