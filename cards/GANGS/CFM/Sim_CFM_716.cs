

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_716",
  "name": [
    "鱼死网破",
    "Sleep with the Fishes"
  ],
  "text": [
    "对所有受伤的随从造成$3点\n伤害。",
    "Deal $3 damage to all damaged minions."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 41414
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_716 : SimTemplate //* Sleep with the Fishes
    {
        // Deal 3 damage to all damaged minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            foreach (var m in p.ownMinions)
            {
                if (m.wounded)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.wounded)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }
    }
}