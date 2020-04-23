

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_001",
  "name": [
    "烈焰轰击",
    "Flamecannon"
  ],
  "text": [
    "随机对一个敌方随从造成\n$4 点伤害。",
    "Deal $4 damage to a random enemy minion."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1927
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_001 : SimTemplate //Flamecannon
    {
        //    Deal $4 damage to a random enemy minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // optimistic

            var temp = ownplay ? p.enemyMinions : p.ownMinions;
            var times = ownplay ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            if (temp.Count >= 1)
            {
                //search Minion with lowest hp
                var enemy = temp[0];
                var minhp = 10000;
                foreach (var m in temp)
                {
                    if (m.Hp >= times + 1 && minhp > m.Hp)
                    {
                        enemy = m;
                        minhp = m.Hp;
                    }
                }

                p.minionGetDamageOrHeal(enemy, times);
            }
        }
    }
}