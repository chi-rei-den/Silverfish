using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_624",
  "name": [
    "神圣之火",
    "Holy Fire"
  ],
  "text": [
    "造成$5点伤害。为你的英雄恢复#5点生命值。",
    "Deal $5 damage. Restore #5 Health to your hero."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1365
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_624 : SimTemplate //holyfire
    {

        //    verursacht $5 schaden. stellt bei eurem helden #5 leben wieder her.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            int heal = (ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);

            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}