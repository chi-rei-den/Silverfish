

/* _BEGIN_TEMPLATE_
{
  "id": "OG_080f",
  "name": [
    "火焰花毒素",
    "Firebloom Toxin"
  ],
  "text": [
    "造成$2点伤害。",
    "Deal $2 damage."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38935
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_080f : SimTemplate //* Firebloom Toxin
    {
        //Deal 2 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}