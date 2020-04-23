

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_222",
  "name": [
    "暴风城勇士",
    "Stormwind Champion"
  ],
  "text": [
    "你的其他随从获得+1/+1。",
    "Your other minions have +1/+1."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 753
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_222 : SimTemplate //stormwindchampion
    {
//    eure anderen diener haben +1/+1.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnStormwindChamps++;
                foreach (var m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 1);
                    }
                }
            }
            else
            {
                p.anzEnemyStormwindChamps++;
                foreach (var m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
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
                p.anzOwnStormwindChamps--;
                foreach (var m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
                    }
                }
            }
            else
            {
                p.anzEnemyStormwindChamps--;
                foreach (var m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, -1);
                    }
                }
            }
        }
    }
}