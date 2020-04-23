using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_037b",
  "name": [
    "并蒂树苗",
    "One, Two, Trees!"
  ],
  "text": [
    "召唤两个1/1的树苗。",
    "Summon two 1/1 Saplings."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2791
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_037b : SimTemplate //* Living Roots
    {
        //Summon two 1/1 Saplings.

        SimCard kid = CardIds.NonCollectible.Druid.LivingRoots_SaplingToken; //Sapling

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, place, ownplay, false);
            p.callKid(this.kid, place, ownplay);
        }
    }
}