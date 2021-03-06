

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_062",
  "name": [
    "地狱烈焰",
    "Hellfire"
  ],
  "text": [
    "对所有角色造成$3点伤害。",
    "Deal $3 damage to ALL characters."
  ],
  "CardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 950
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_062 : SimTemplate //hellfire
    {
//    fügt allen charakteren $3 schaden zu.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allCharsGetDamage(dmg);
        }
    }
}