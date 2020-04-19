using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_052",
  "name": [
    "空气之怒图腾",
    "Wrath of Air Totem"
  ],
  "text": [
    "<b>法术伤害+1</b>",
    "<b>Spell Damage +1</b>"
  ],
  "CardClass": "SHAMAN",
  "type": "MINION",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 458
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_052 : SimTemplate //wrathofairtotem
	{

//    zauberschaden +1/
		public override void  onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
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