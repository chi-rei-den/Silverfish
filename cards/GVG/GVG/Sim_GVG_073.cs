

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_073",
  "name": [
    "眼镜蛇射击",
    "Cobra Shot"
  ],
  "text": [
    "对一个随从和敌方英雄造成$3点伤害。",
    "Deal $3 damage to a minion and the enemy hero."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2041
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_073 : SimTemplate //Cobra Shot
    {
        //   Deal $3 damage to a minion and the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            p.minionGetDamageOrHeal(target, dmg);

            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
        }
    }
}