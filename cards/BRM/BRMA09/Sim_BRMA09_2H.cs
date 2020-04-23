using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA09_2H",
  "name": [
    "打开大门",
    "Open the Gates"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤三个2/2的雏龙。获得另一个英雄技能。",
    "<b>Hero Power</b>\nSummon three 2/2 Whelps. Get a new Hero Power."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2530
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA09_2H : SimTemplate //* Open the Gates
    {
        // Hero Power: Summon three 2/2 Whelps. Get a new Hero Power.

        SimCard kid = CardIds.NonCollectible.Neutral.OpentheGatesHeroic_WhelpTokenBRS; //2/2Whelp

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, place, ownplay, false);
            p.callKid(this.kid, place, ownplay);
            p.callKid(this.kid, place, ownplay);
        }
    }
}