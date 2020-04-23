

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_137",
  "name": [
    "裂颅之击",
    "Headcrack"
  ],
  "text": [
    "对敌方英雄造成$2点伤害；<b>连击：</b>在下个回合将其移回你的手牌。",
    "Deal $2 damage to the enemy hero. <b>Combo:</b> Return this to your hand next turn."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 708
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_137 : SimTemplate //headcrack
    {
        //    fügt dem feindlichen helden $2 schaden zu. combo:/ lasst die karte in eurem nächsten zug wieder auf eure hand zurückkehren.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);

            if (p.cardsPlayedThisTurn >= 1)
            {
                p.evaluatePenality -= 5;
            }
        }
    }
}