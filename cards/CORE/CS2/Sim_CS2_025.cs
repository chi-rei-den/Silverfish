

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_025",
  "name": [
    "魔爆术",
    "Arcane Explosion"
  ],
  "text": [
    "对所有敌方随从造成$1点伤害。",
    "Deal $1 damage to all enemy minions."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 447
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_025 : SimTemplate //arcaneexplosion
    {
//    fügt allen feindlichen dienern $1 schaden zu.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }
    }
}