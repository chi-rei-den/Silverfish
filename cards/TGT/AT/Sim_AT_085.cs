using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_085",
  "name": [
    "湖之仙女",
    "Maiden of the Lake"
  ],
  "text": [
    "你的英雄技能的法力值消耗为（1）点。",
    "Your Hero Power costs (1)."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2488
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_085 : SimCard //* Maiden of the Lake
	{
		//Your Hero Power costs (1).
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
				if (p.ownHeroAblility.manacost > 1) p.ownHeroAblility.manacost--;
            }
            else
            {				
				if (p.enemyHeroAblility.manacost > 1) p.enemyHeroAblility.manacost--;
            }
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
			bool another = false;
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
					if (m.name == CardDB.cardName.maidenofthelake && !m.silenced && own.entitiyID != m.entitiyID) another = true;
                }
				if (!another) p.ownHeroAblility.manacost++;
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
					if (m.name == CardDB.cardName.maidenofthelake && !m.silenced && own.entitiyID != m.entitiyID) another = true;
                }
				if (!another) p.enemyHeroAblility.manacost++;
            }
        }
	}
}