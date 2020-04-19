using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_082",
  "name": [
    "寒冰克隆",
    "Frozen Clone"
  ],
  "text": [
    "<b>奥秘：</b>在你的对手使用一张随从牌后，将两张该随从的复制置入你的手牌。",
    "<b>Secret:</b> After your opponent plays a minion, add two copies of it to your hand."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42754
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_082: SimTemplate //* Frozen Clone
    {
        // Secret: After your opponent plays a minion, add two copies of it to your hand.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.drawACard(SimCard.None, ownplay, true);
            p.drawACard(SimCard.None, ownplay, true);
        }
    }
}