

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_011",
  "name": [
    "熔岩震击",
    "Lava Shock"
  ],
  "text": [
    "造成$2点伤害。\n将你所有<b>过载</b>的法力水晶解锁。",
    "Deal $2 damage.\nUnlock your <b>Overloaded</b> Mana Crystals."
  ],
  "CardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2289
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_011 : SimTemplate //* Lava Shock
    {
        // Deal 2 damage. Unlock your Overloaded Mana Crystals.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay)
            {
                p.unlockMana();
            }
        }
    }
}