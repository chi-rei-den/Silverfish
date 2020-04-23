

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA04_2",
  "name": [
    "熔岩脉动",
    "Magma Pulse"
  ],
  "text": [
    "<b>英雄技能</b>\n对所有随从造成1点伤害。",
    "<b>Hero Power</b>\nDeal 1 damage to all minions."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2325
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA04_2 : SimTemplate //* Magma Pulse
    {
        // Hero Power: Deal 1 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.allMinionsGetDamage(dmg);
        }
    }
}