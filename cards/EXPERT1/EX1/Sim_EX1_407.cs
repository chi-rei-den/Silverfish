using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_407",
  "name": [
    "绝命乱斗",
    "Brawl"
  ],
  "text": [
    "随机选择一个随从，消灭除了该随从外的所有其他随从。",
    "Destroy all minions except one. <i>(chosen randomly)</i>"
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 75
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_407 : SimTemplate //* Brawl
    {
        // Destroy all minions except one. (chosen randomly)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var hasWinner = false;
            foreach (var m in p.enemyMinions)
            {
                if ((m.name == CardIds.NonCollectible.Neutral.DarkIronBouncer || m.name == CardIds.NonCollectible.Neutral.CorenDirebrew2) && !hasWinner)
                {
                    hasWinner = true;
                    continue;
                }

                p.minionGetDestroyed(m);
            }

            foreach (var m in p.ownMinions)
            {
                if ((m.name == CardIds.NonCollectible.Neutral.DarkIronBouncer || m.name == CardIds.NonCollectible.Neutral.CorenDirebrew2) && !hasWinner)
                {
                    hasWinner = true;
                    continue;
                }

                p.minionGetDestroyed(m);
            }
        }
    }
}