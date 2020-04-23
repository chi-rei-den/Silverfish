

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_032",
  "name": [
    "烈焰风暴",
    "Flamestrike"
  ],
  "text": [
    "对所有敌方随从造成$4点伤害。",
    "Deal $4 damage to all enemy minions."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 7,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1004
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_032 : SimTemplate //flamestrike
    {
//    fügt allen feindlichen dienern $4 schaden zu.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }
    }
}