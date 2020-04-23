

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_094",
  "name": [
    "邪火药水",
    "Felfire Potion"
  ],
  "text": [
    "对所有角色造成$5点伤害。",
    "Deal $5 damage to all characters."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40517
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_094 : SimTemplate //* Felfire Potion
    {
        // Deal 5 damage to all characters.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.allCharsGetDamage(dmg);
        }
    }
}