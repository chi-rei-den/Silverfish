using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_608",
  "name": [
    "巫师学徒",
    "Sorcerer's Apprentice"
  ],
  "text": [
    "你的法术的法力值消耗减少（1）点。",
    "Your spells cost (1) less."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 614
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_608 : SimTemplate //* Sorcerer's Apprentice
	{
        // Your spells cost (1) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownSpelsCostMore--;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.ownSpelsCostMore++;
        }
	}
}