

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t16",
  "name": [
    "火焰之心",
    "Heart of Fire"
  ],
  "text": [
    "造成$5点伤害。",
    "Deal $5 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41605
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t16 : SimTemplate //* Heart of Fire
    {
        // Deal $5 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}