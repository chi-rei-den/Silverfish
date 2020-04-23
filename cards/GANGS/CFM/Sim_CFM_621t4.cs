

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t4",
  "name": [
    "邪能花",
    "Felbloom"
  ],
  "text": [
    "对所有随从造成$2点伤害。",
    "Deal $2 damage to all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41588
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t4 : SimTemplate //* Felbloom
    {
        // Deal $2 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionsGetDamage(dmg);
        }
    }
}