

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t33",
  "name": [
    "邪能花",
    "Felbloom"
  ],
  "text": [
    "对所有随从造成$6点伤害。",
    "Deal $6 damage to all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41629
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_621t33 : SimTemplate //* Felbloom
    {
        // Deal $6 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.allMinionsGetDamage(dmg);
        }
    }
}