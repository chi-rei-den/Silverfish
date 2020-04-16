using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_039",
  "name": [
    "黑暗裁决",
    "Dark Conviction"
  ],
  "text": [
    "将一个随从的攻击力和生命值\n变为3。",
    "Set a minion's Attack and Health to 3."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42469
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_039: SimTemplate //* Dark Conviction
    {
        // Set a minion's Attack and Health to 3.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSetAngrToX(target, 3);
            p.minionSetLifetoX(target, 3);
        }
    }
}