using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX1h_04",
  "name": [
    "飞掠召唤",
    "Skitter"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个4/4的\n蛛魔。",
    "<b>Hero Power</b>\nSummon a 4/4 Nerubian."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2103
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX1h_04 : SimTemplate //* Skitter
    {
        // Hero Power: Summon a 4/4 Nerubian.

        SimCard kid = CardIds.NonCollectible.Neutral.NerubianHeroic; //4/4Nerubian

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, place, ownplay, false);
        }
    }
}