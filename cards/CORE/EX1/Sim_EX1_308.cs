

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_308",
  "name": [
    "灵魂之火",
    "Soulfire"
  ],
  "text": [
    "造成$4点伤害，随机弃一\n张牌。",
    "[x]Deal $4 damage.\nDiscard a random card."
  ],
  "CardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 974
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_308 : SimTemplate //* Soulfire
    {
        // Deal $4 damage. Discard a random card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            p.discardCards(1, ownplay);
        }
    }
}