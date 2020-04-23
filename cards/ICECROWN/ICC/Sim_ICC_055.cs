

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_055",
  "name": [
    "吸取灵魂",
    "Drain Soul"
  ],
  "text": [
    "<b>吸血</b>\n对一个随从造成\n$2点伤害。",
    "<b>Lifesteal</b>\nDeal $2 damage\nto a minion."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42658
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_055 : SimTemplate //* Drain Soul
    {
        // Lifesteal. Deal 2 damage to a minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            var oldHp = target.Hp;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.Hp)
            {
                p.applySpellLifesteal(oldHp - target.Hp, ownplay);
            }
        }
    }
}