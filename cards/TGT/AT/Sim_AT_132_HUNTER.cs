

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_HUNTER",
  "name": [
    "弩炮射击",
    "Ballista Shot"
  ],
  "text": [
    "<b>英雄技能</b>\n对敌方英雄造成$3点伤害。",
    "<b>Hero Power</b>\nDeal $3 damage to the enemy hero."
  ],
  "cardClass": "HUNTER",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2738
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_132_HUNTER : SimTemplate //* Ballista Shot
    {
        //Hero Power: Deal 3 damage to the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            if (target == null)
            {
                target = ownplay ? p.enemyHero : p.ownHero;
            }

            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}