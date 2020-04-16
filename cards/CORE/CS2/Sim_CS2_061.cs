using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_061",
  "name": [
    "吸取生命",
    "Drain Life"
  ],
  "text": [
    "造成$2点伤害，为你的英雄恢复#2点生命值。",
    "Deal $2 damage. Restore #2 Health to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 919
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_061 : SimTemplate //drainlife
    {

        //    verursacht $2 schaden. stellt bei eurem helden #2 leben wieder her.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            int heal = (ownplay) ? p.getSpellHeal(2) : p.getEnemySpellHeal(2);
            p.minionGetDamageOrHeal(target, dmg);

            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}