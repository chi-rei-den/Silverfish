

/* _BEGIN_TEMPLATE_
{
  "id": "NAX1_05",
  "name": [
    "虫群风暴",
    "Locust Swarm"
  ],
  "text": [
    "对所有敌方随从造成$3点伤害。为你的英雄恢复#3点生命值。",
    "Deal $3 damage to all enemy minions. Restore #3 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1832
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX1_05 : SimTemplate //* Locust Swarm
    {
        //Deal $3 damage to all enemy minions. Restore #3 Health to your hero.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            var heal = ownplay ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);
            if (ownplay)
            {
                p.minionGetDamageOrHeal(p.ownHero, -heal);
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
                foreach (var m in p.enemyMinions)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
                p.minionGetDamageOrHeal(p.ownHero, dmg);
                foreach (var m in p.ownMinions)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }
    }
}