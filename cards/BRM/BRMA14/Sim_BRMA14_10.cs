using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA14_10",
  "name": [
    "激活！",
    "Activate!"
  ],
  "text": [
    "<b>英雄技能</b>\n随机激活一个金刚。",
    "<b>Hero Power</b>\nActivate a random Tron."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 4,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2386
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA14_10 : SimTemplate //* Activate!
    {
        // Hero Power: Activate a random Tron.

        SimCard kid = CardIds.NonCollectible.Neutral.Toxitron; //3/3toxitron

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, place, ownplay, false);
        }
    }
}