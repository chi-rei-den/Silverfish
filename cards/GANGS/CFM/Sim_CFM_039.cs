using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_039",
  "name": [
    "杂耍小鬼",
    "Street Trickster"
  ],
  "text": [
    "<b>法术伤害+1</b>",
    "<b>Spell Damage +1</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40213
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_039 : SimCard //* Street Trickster
	{
		// Spell Damage +1

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own) p.spellpower++;
            else p.enemyspellpower++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower--;
            else p.enemyspellpower--;
        }
    }
}