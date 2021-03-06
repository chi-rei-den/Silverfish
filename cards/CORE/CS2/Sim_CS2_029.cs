

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_029",
  "name": [
    "火球术",
    "Fireball"
  ],
  "text": [
    "造成$6点伤害。",
    "Deal $6 damage."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 315
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_029 : SimTemplate //fireball
    {
//    verursacht $6 schaden.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}