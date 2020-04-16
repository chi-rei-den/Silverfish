using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_901",
  "name": [
    "达卡莱附魔师",
    "Drakkari Enchanter"
  ],
  "text": [
    "你的回合结束效果会生效两次。",
    "Your end of turn effects trigger twice."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45309
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_901: SimTemplate //* Drakkari Enchanter
    {
        // Your end of turn effects trigger twice.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownTurnEndEffectsTriggerTwice++;
            else p.enemyTurnEndEffectsTriggerTwice++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.ownTurnEndEffectsTriggerTwice--;
            else p.enemyTurnEndEffectsTriggerTwice--;
        }
    }
}