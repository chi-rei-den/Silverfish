using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_051",
  "name": [
    "丛林枭兽",
    "Jungle Moonkin"
  ],
  "text": [
    "每个玩家获得\n<b>法术伤害+2</b>。",
    "Both players have\n<b>Spell Damage +2</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2923
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_051 : SimCard //* Jungle Moonkin
	{
		//Both players have Spell Damage +2.

        public override void onAuraStarts(Playfield p, Minion own)
		{
			p.spellpower+=2;
			p.enemyspellpower+=2;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
			p.spellpower-=2;
			p.enemyspellpower-=2;
        }
	}
}