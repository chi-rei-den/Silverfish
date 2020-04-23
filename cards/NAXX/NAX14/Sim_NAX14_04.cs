

/* _BEGIN_TEMPLATE_
{
  "id": "NAX14_04",
  "name": [
    "极寒之击",
    "Pure Cold"
  ],
  "text": [
    "对敌方英雄造成$8点伤害，并使其<b>冻结</b>。",
    "Deal $8 damage to the enemy hero, and <b>Freeze</b> it."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1907
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX14_04 : SimTemplate //* purecold
    {
        //Deal 8 damage to the enemy hero, and and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
            target = ownplay ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, dmg, true);
            p.minionGetFrozen(target);
        }
    }
}