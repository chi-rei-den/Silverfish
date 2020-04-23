

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_802",
  "name": [
    "灵魂鞭笞",
    "Spirit Lash"
  ],
  "text": [
    "<b>吸血</b>\n对所有随从造成\n$1点伤害。",
    "<b>Lifesteal</b>\nDeal $1 damage to all minions."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42992
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_802 : SimTemplate //* Spirit Lash
    {
        // Lifesteal. Deal 1 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            var heal = 0;
            var tmp = ownplay ? p.enemyMinions : p.ownMinions;
            foreach (var m in tmp)
            {
                heal += m.Hp;
            }

            p.allMinionOfASideGetDamage(!ownplay, dmg);
            foreach (var m in tmp)
            {
                heal -= m.Hp;
            }

            p.applySpellLifesteal(heal, ownplay);
        }
    }
}