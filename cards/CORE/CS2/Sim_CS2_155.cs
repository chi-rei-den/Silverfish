using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_155",
  "name": [
    "大法师",
    "Archmage"
  ],
  "text": [
    "<b>法术伤害+1</b>",
    "<b>Spell Damage +1</b>"
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 525
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_155 : SimTemplate //archmage
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