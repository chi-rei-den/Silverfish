using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_084",
  "name": [
    "战歌指挥官",
    "Warsong Commander"
  ],
  "text": [
    "你的具有<b>冲锋</b>的随从获得+1攻击力。",
    "Your <b>Charge</b> minions have +1 Attack."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1009
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_084 : SimCard //* Warsong Commander
    {
		//Your Charge minions have +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, 1, 0);
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, 1, 0);
                }
            }
            
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, -1, 0);
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.charge > 0) p.minionGetBuffed(m, -1, 0);
                }
            }
        }
	}
}