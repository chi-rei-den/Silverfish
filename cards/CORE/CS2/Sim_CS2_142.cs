using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_142",
  "name": [
    "狗头人地卜师",
    "Kobold Geomancer"
  ],
  "text": [
    "<b>法术伤害+1</b>",
    "<b>Spell Damage +1</b>"
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 672
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_142 : SimTemplate //koboldgeomancer
	{

//    zauberschaden +1/
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {

            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }

	}
}