using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_196",
  "name": [
    "剃刀猎手",
    "Razorfen Hunter"
  ],
  "text": [
    "<b>战吼：</b>召唤一个1/1的野猪。",
    "<b>Battlecry:</b> Summon a 1/1 Boar."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 257
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_196 : SimTemplate //* razorfenhunter
    {
        //Battlecry: Summon a 1/1 Boar.
        SimCard kid = CardIds.NonCollectible.Neutral.Boar; //boar

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(this.kid, own.zonepos, own.own);
        }
    }
}