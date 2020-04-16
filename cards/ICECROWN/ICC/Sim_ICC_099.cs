using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_099",
  "name": [
    "自爆憎恶",
    "Ticking Abomination"
  ],
  "text": [
    "<b>亡语：</b>对你所有的随从造成5点伤害。",
    "<b>Deathrattle:</b> Deal 5 damage to your minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42782
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_099: SimTemplate //* Ticking Abomination
    {
        // Deathrattle: Deal 5 damage to your minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(m.own, 5);
        }
    }
}