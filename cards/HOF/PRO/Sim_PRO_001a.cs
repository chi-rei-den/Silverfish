using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "PRO_001a",
  "name": [
    "我是鱼人",
    "I Am Murloc"
  ],
  "text": [
    "召唤三个、四个或者五个1/1的\n鱼人。",
    "Summon three, four, or five 1/1 Murlocs."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 1843
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PRO_001a : SimTemplate //I Am Murloc
    {
        //Summon three, four, or five 1/1 Murlocs.
        SimCard kid = CardIds.NonCollectible.Neutral.EliteTaurenChieftain_Murloc;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var posi = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, posi, ownplay, false);
            p.callKid(this.kid, posi, ownplay);
            p.callKid(this.kid, posi, ownplay);
            p.callKid(this.kid, posi, ownplay);
        }
    }
}