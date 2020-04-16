using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_083",
  "name": [
    "末日学徒",
    "Doomed Apprentice"
  ],
  "text": [
    "你对手法术的法力值消耗增加（1）点。",
    "Your opponent's spells cost (1) more."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42756
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_083: SimTemplate //* Doomed Apprentice
    {
        // Your opponent's spells cost (1) more.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (!own.own) p.ownSpelsCostMore++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (!own.own) p.ownSpelsCostMore--;
        }
    }
}