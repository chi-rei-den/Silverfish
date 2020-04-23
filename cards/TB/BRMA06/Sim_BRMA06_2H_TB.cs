using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA06_2H_TB",
  "name": [
    "火妖管理者",
    "The Majordomo"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个3/3的火妖卫士。",
    "<b>Hero Power</b>\nSummon a 3/3 Flamewaker Acolyte."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 36736
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA06_2H_TB : SimTemplate //* The Majordomo
    {
        // Hero Power: Summon a 3/3 Flamewaker Acolyte.

        SimCard kid = CardIds.NonCollectible.Neutral.FlamewakerAcolyteHeroic; //3/3Flamewaker Acolyte

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, place, ownplay, false);
        }
    }
}