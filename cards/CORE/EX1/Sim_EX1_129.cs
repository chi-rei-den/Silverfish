using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_129",
  "name": [
    "刀扇",
    "Fan of Knives"
  ],
  "text": [
    "对所有敌方随从造成$1点伤害，抽一张牌。",
    "Deal $1 damage to all enemy minions. Draw a card."
  ],
  "CardClass": "ROGUE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 667
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_129 : SimTemplate //fanofknives
    {
//    fügt allen feindlichen dienern $1 schaden zu. zieht eine karte.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            p.drawACard(SimCard.None, ownplay);
        }
    }
}