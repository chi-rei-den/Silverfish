using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_856",
  "name": [
    "织法者",
    "Spellweaver"
  ],
  "text": [
    "<b>法术伤害+2</b>",
    "<b>Spell Damage +2</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45378
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_856: SimTemplate //* Spellweaver
    {
        // Spell Damage +2

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.spellpower += 2;
            else p.enemyspellpower += 2;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower -= 2;
            else p.enemyspellpower -= 2;
        }
    }
}