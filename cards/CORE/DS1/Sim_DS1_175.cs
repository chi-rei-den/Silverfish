using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_175",
  "name": [
    "森林狼",
    "Timber Wolf"
  ],
  "text": [
    "你的其他野兽获得+1攻击力。",
    "Your other Beasts have +1 Attack."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 606
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DS1_175 : SimTemplate //timberwolf
	{

//    eure anderen wildtiere haben +1 angriff.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTimberWolfs++;
                foreach (Minion m in p.ownMinions)
                {
                    if ((Race)m.handcard.card.Race == Race.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, 1, 0);
                }
            }
            else
            {
                p.anzEnemyTimberWolfs++;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((Race)m.handcard.card.Race == Race.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, 1, 0);
                }
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnTimberWolfs--;
                foreach (Minion m in p.ownMinions)
                {
                    if ((Race)m.handcard.card.Race == Race.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, -1, 0);
                }
            }
            else
            {
                p.anzEnemyTimberWolfs--;
                foreach (Minion m in p.enemyMinions)
                {
                    if ((Race)m.handcard.card.Race == Race.PET && m.entitiyID != own.entitiyID) p.minionGetBuffed(m, -1, 0);
                }
            }
        }

	}
}