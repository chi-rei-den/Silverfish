

/* _BEGIN_TEMPLATE_
{
  "id": "AT_004",
  "name": [
    "奥术冲击",
    "Arcane Blast"
  ],
  "text": [
    "对一个随从造成$2点伤害。该法术受到的<b>法术伤害</b>增益效果翻倍。",
    "Deal $2 damage to a minion. This spell gets double bonus from <b>Spell Damage</b>."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2572
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_004 : SimTemplate //* Arcane Blast
    {
        //Deal 2 damage to a minion. This spell gets double bonus from Spell Damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2 + p.spellpower) : p.getEnemySpellDamageDamage(2 + p.enemyspellpower);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}