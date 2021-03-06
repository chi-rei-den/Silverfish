using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_571",
  "name": [
    "自然之力",
    "Force of Nature"
  ],
  "text": [
    "召唤三个2/2的树人。",
    "Summon three 2/2 Treants."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 493
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_571 : SimTemplate //* Force of Nature
    {
        //Summon three 2/2 Treants.

        SimCard kid = CardIds.NonCollectible.Druid.SouloftheForest_TreantToken; //Treant

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, pos, ownplay, false);
            p.callKid(this.kid, pos, ownplay);
            p.callKid(this.kid, pos, ownplay);
        }
    }
}