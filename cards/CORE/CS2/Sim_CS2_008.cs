

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_008",
  "name": [
    "月火术",
    "Moonfire"
  ],
  "text": [
    "造成$1点伤害。",
    "Deal $1 damage."
  ],
  "CardClass": "DRUID",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 467
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_008 : SimTemplate //moonfire
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}