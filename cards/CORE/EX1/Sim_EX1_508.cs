using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_508",
  "name": [
    "暗鳞先知",
    "Grimscale Oracle"
  ],
  "text": [
    "你的其他鱼人获得+1攻击力。",
    "Your other Murlocs have +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 510
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_508 : SimTemplate //* Grimscale Oracle
    {
        //Your other Murlocs have +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnGrimscaleOracle++;
            else p.anzEnemyGrimscaleOracle++;

            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MURLOC && own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 0);
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnGrimscaleOracle--;
            else p.anzEnemyGrimscaleOracle--;

            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
                if ((TAG_RACE)mn.handcard.card.Race == TAG_RACE.MURLOC && mn.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, 0);
            }
        }
    }
}
