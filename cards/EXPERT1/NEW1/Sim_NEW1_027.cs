using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_027",
  "name": [
    "南海船长",
    "Southsea Captain"
  ],
  "text": [
    "你的其他海盗获得+1/+1。",
    "Your other Pirates have +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 680
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_027 : SimTemplate //southseacaptain
    {
//    eure anderen piraten haben +1/+1.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnSouthseacaptain++;
                foreach (var m in p.ownMinions)
                {
                    if (m.handcard.card.Race == Race.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
            else
            {
                p.anzEnemySouthseacaptain++;
                foreach (var m in p.enemyMinions)
                {
                    if (m.handcard.card.Race == Race.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnSouthseacaptain--;
                foreach (var m in p.ownMinions)
                {
                    if (m.handcard.card.Race == Race.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
                    }
                }
            }
            else
            {
                p.anzEnemySouthseacaptain--;
                foreach (var m in p.enemyMinions)
                {
                    if (m.handcard.card.Race == Race.PIRATE && own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
                    }
                }
            }
        }
    }
}