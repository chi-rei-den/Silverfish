using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_003",
  "name": [
    "牺牲契约",
    "Sacrificial Pact"
  ],
  "text": [
    "牺牲一个恶魔，为你的英雄恢复#5点生命值。",
    "Destroy a Demon. Restore #5 Health to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 163
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_003 : SimCard //sacrificialpact
    {

        //    vernichtet einen dämon. stellt bei eurem helden #5 leben wieder her.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            int heal = (ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}