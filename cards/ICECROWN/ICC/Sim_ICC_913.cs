using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_913",
  "name": [
    "被污染的狂热者",
    "Tainted Zealot"
  ],
  "text": [
    "<b>圣盾</b>\n<b>法术伤害+1</b>",
    "<b>Divine Shield</b>\n<b>Spell Damage +1</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 46103
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_913: SimCard //* Tainted Zealot
    {
        // Divine Shield. Spell Damage + 1.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.spellpower++;
            else p.enemyspellpower++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower--;
            else p.enemyspellpower--;
        }
    }
}