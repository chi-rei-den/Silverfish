using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_062",
  "name": [
    "天降蛛群",
    "Ball of Spiders"
  ],
  "text": [
    "召唤三个1/1的结网蛛。",
    "Summon three 1/1 Webspinners."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2483
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_062 : SimTemplate //* Ball of Spiders
    {
        //Summon three 1/1 Webspinners.

        SimCard kid = CardIds.Collectible.Hunter.Webspinner; //Webspinner

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, place, ownplay, false);
            p.callKid(this.kid, place, ownplay);
            p.callKid(this.kid, place, ownplay);
        }
    }
}