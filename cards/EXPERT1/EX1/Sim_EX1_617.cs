using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_617",
  "name": [
    "致命射击",
    "Deadly Shot"
  ],
  "text": [
    "随机消灭一个敌方随从。",
    "Destroy a random enemy minion."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1093
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_617 : SimTemplate //* Deadly Shot
    {
        // Destroy a random enemy minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var m = p.searchRandomMinion(ownplay ? p.enemyMinions : p.ownMinions, SearchMode.LowHealth);
            if (m != null)
            {
                p.minionGetDestroyed(m);
            }
        }
    }
}