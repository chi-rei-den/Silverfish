

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_002t",
  "name": [
    "炽烈的火把",
    "Roaring Torch"
  ],
  "text": [
    "造成$6点伤害。",
    "Deal $6 damage."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 2997
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_002t : SimTemplate //* Roaring Torch
    {
        //Deal 6 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}