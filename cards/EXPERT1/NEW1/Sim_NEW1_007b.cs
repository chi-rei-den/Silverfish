

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_007b",
  "name": [
    "星辰领主",
    "Starlord"
  ],
  "text": [
    "对一个随从造成$5点伤害。",
    "Deal $5 damage to a minion."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 928
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_007b : SimTemplate //starfall choice left
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}