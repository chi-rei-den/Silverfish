using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX4_05",
  "name": [
    "瘟疫",
    "Plague"
  ],
  "text": [
    "消灭所有不是骷髅的随从。",
    "Destroy all non-Skeleton minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1850
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX4_05 : SimTemplate //* Plague
    {
        // Destroy all non-Skeleton minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (var m in p.ownMinions)
            {
                if (m.name != CardIds.NonCollectible.Neutral.SkeletonNAXX)
                {
                    p.minionGetDestroyed(m);
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.name != CardIds.NonCollectible.Neutral.SkeletonNAXX)
                {
                    p.minionGetDestroyed(m);
                }
            }
        }
    }
}