using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_119",
  "name": [
    "复活的铠甲",
    "Animated Armor"
  ],
  "text": [
    "你的英雄每次只会受到1点伤害。",
    "Your hero can only take 1 damage at a time."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 36111
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_119 : SimCard //* Animated Armor
	{
		//Your hero can only take 1 damage at a time.
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.anzOwnAnimatedArmor++;
            else p.anzEnemyAnimatedArmor++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnAnimatedArmor--;
            else p.anzEnemyAnimatedArmor--;
        }
	}
}