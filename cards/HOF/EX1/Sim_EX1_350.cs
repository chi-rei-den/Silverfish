using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_350",
  "name": [
    "先知维伦",
    "Prophet Velen"
  ],
  "text": [
    "使你的法术和英雄技能的伤害和治疗效果翻倍。",
    "Double the damage and healing of your spells and Hero Power."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 9
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_350 : SimCard //prophetvelen
	{

//    verdoppelt den schaden und die heilung eurer zauber und heldenfähigkeiten.
		public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                p.doublepriest++;
            }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.doublepriest--;
            }
        }

	}
}