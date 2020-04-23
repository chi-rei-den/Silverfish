

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_111",
  "name": [
    "极恶之咒",
    "Excavated Evil"
  ],
  "text": [
    "对所有随从造成$3点伤害。将该牌洗入你对手的牌库。",
    "Deal $3 damage to all minions.\nShuffle this card into your opponent's deck."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2999
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_111 : SimTemplate //* Excavated Evil
    {
        //Deal 3 damage to all minions. Shuffle this card into your opponent's deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionsGetDamage(dmg);
            if (ownplay)
            {
                p.enemyDeckSize++;
            }
            else
            {
                p.ownDeckSize++;
            }
        }
    }
}