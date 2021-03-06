using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA06_2",
  "name": [
    "火妖管理者",
    "The Majordomo"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个1/3的火妖卫士。",
    "<b>Hero Power</b>\nSummon a 1/3 Flamewaker Acolyte."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2335
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA06_2 : SimTemplate //* The Majordomo
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(CardIds.NonCollectible.Neutral.FlamewakerAcolyte, place, ownplay, false);
        }
    }
}