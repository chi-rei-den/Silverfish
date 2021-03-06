

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_033",
  "name": [
    "雷欧克",
    "Leokk"
  ],
  "text": [
    "你的其他随从获得+1攻击力。",
    "Your other minions have +1 Attack."
  ],
  "CardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "CORE",
  "collectible": null,
  "dbfId": 226
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_033 : SimTemplate //leokk
    {
//    andere befreundete diener haben +1 angriff.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnRaidleader++;
                foreach (var m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 0);
                    }
                }
            }
            else
            {
                p.anzEnemyRaidleader++;
                foreach (var m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, 1, 0);
                    }
                }
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnRaidleader--;
                foreach (var m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, 0);
                    }
                }
            }
            else
            {
                p.anzEnemyRaidleader--;
                foreach (var m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID)
                    {
                        p.minionGetBuffed(m, -1, 0);
                    }
                }
            }
        }
    }
}