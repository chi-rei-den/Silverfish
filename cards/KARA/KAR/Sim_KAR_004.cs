using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_004",
  "name": [
    "豹子戏法",
    "Cat Trick"
  ],
  "text": [
    "<b>奥秘：</b>在你的对手施放一个法术后，召唤一个4/2并具有<b>潜行</b>的猎豹。",
    "<b>Secret:</b> After your opponent casts a spell, summon a 4/2 Panther with <b>Stealth</b>."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39160
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_004 : SimTemplate //* Cat Trick
    {
        //Secret: After your opponent casts a spell, summon a 4/2 Panther with Stealth.

        SimCard kid = CardIds.NonCollectible.Hunter.CatTrick_CatInAHat; //Panther - Cat in a Hat

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
        }
    }
}