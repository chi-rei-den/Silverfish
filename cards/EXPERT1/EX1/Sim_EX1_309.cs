using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_309",
  "name": [
    "灵魂虹吸",
    "Siphon Soul"
  ],
  "text": [
    "消灭一个随从，为你的英雄恢复#3点生命值。",
    "Destroy a minion. Restore #3 Health to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1100
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_309 : SimTemplate//Siphon Soul
    {
        //Vernichtet einen Diener. Stellt bei Eurem Helden #3 Leben wieder her.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            int heal = (ownplay) ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);

            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }

    }
}
