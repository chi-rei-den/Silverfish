using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_563",
  "name": [
    "玛里苟斯",
    "Malygos"
  ],
  "text": [
    "<b>法术伤害+5</b>",
    "<b>Spell Damage +5</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 436
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_563 : SimCard //malygos
	{

//    zauberschaden +5/
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                p.spellpower+=5;
            }
            else
            {
                p.enemyspellpower+=5;
            }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower -= 5;
            }
            else
            {
                p.enemyspellpower -= 5;
            }
        }

	}
}