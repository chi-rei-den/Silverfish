using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_808",
  "name": [
    "地穴领主",
    "Crypt Lord"
  ],
  "text": [
    "<b>嘲讽</b>\n在你召唤一个随从后，获得+1生命值。",
    "[x]<b>Taunt</b>\nAfter you summon a minion,\n gain +1 Health."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43025
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_808: SimCard //* Crypt Lord
    {
        // Taunt. After you summon a minion, gain +1 Health.
        
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.minionGetBuffed(m, 0, 1);
            }
        }
    }
}