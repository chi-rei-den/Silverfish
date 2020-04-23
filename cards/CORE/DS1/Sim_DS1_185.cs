

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_185",
  "name": [
    "奥术射击",
    "Arcane Shot"
  ],
  "text": [
    "造成$2点伤害。",
    "Deal $2 damage."
  ],
  "CardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 877
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DS1_185 : SimTemplate //arcaneshot
    {
//    verursacht $2 schaden.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}