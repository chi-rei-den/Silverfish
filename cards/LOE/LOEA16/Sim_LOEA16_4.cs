

/* _BEGIN_TEMPLATE_
{
  "id": "LOEA16_4",
  "name": [
    "恐怖丧钟",
    "Timepiece of Horror"
  ],
  "text": [
    "造成$10点伤害，随机分配到所有敌人身上。",
    "Deal $10 damage randomly split among all enemies."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 19615
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOEA16_4 : SimTemplate //* Timepiece of Horror
    {
        //Deal $10 damage randomly split among all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var times = ownplay ? p.getSpellDamageDamage(10) : p.getEnemySpellDamageDamage(10);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}