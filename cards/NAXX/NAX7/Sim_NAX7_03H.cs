

/* _BEGIN_TEMPLATE_
{
  "id": "NAX7_03H",
  "name": [
    "重压打击",
    "Unbalancing Strike"
  ],
  "text": [
    "<b>英雄技能</b>\n造成4点伤害。",
    "<b>Hero Power</b>\nDeal 4 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2129
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX7_03H : SimTemplate //* Unbalancing Strike
    {
        // Hero Power: Deal 4 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getHeroPowerDamage(4) : p.getEnemyHeroPowerDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}