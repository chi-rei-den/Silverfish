using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_133",
  "name": [
    "毁灭之刃",
    "Perdition's Blade"
  ],
  "text": [
    "<b>战吼：</b>造成1点伤害。<b>连击：</b>改为造成2点伤害。",
    "<b>Battlecry:</b> Deal 1 damage. <b>Combo:</b> Deal 2 instead."
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 391
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_133 : SimTemplate //pertitions blade
    {
        SimCard w = CardIds.Collectible.Rogue.PerditionsBlade;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (p.cardsPlayedThisTurn >= 1)
            {
                dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            }

            p.minionGetDamageOrHeal(target, dmg);
            p.equipWeapon(this.w, ownplay);
        }
    }
}