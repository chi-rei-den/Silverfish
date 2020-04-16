using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX2_05",
  "name": [
    "膜拜者",
    "Worshipper"
  ],
  "text": [
    "你的英雄在你的回合获得+1攻击力。",
    "Your hero has +1 Attack on your turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1842
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX2_05 : SimTemplate //* Worshipper
	{
		// Your hero has +1 Attack on your turn.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, 1, 0);
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, -1, 0);
        }
	}
}