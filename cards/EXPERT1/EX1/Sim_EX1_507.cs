using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_507",
  "name": [
    "鱼人领军",
    "Murloc Warleader"
  ],
  "text": [
    "你的其他鱼人获得+2攻击力。",
    "Your other Murlocs have +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1063
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_507 : SimTemplate //* Murloc Warleader
	{
        // Your other Murlocs have +2 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.anzOwnMurlocWarleader++;
            else p.anzEnemyMurlocWarleader++;

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 2, 0);
            }
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnMurlocWarleader--;
            else p.anzEnemyMurlocWarleader--;

            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
                if((TAG_RACE)mn.handcard.card.Race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(m, -2, 0);
            }
		}
	}
}