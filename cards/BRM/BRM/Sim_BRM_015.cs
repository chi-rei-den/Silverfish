

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_015",
  "name": [
    "复仇打击",
    "Revenge"
  ],
  "text": [
    "对所有随从造成$1点伤害。如果你的生命值小于或等于12点，则改为造成$3点伤害。",
    "Deal $1 damage to all minions. If you have 12 or less Health, deal $3 damage instead."
  ],
  "CardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2296
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_015 : SimTemplate //* Revenge
    {
        // Deal 1 damage to all minions. If you have 12 or less Health, deal 3 damage instead.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = 1;
            var heroHealth = ownplay ? p.ownHero.Hp : p.enemyHero.Hp;
            if (heroHealth <= 12)
            {
                dmg = 3;
            }

            dmg = ownplay ? p.getSpellDamageDamage(dmg) : p.getEnemySpellDamageDamage(dmg);
            p.allMinionsGetDamage(dmg);
        }
    }
}