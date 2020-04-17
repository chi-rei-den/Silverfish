using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t6",
  "name": [
    "湮灭",
    "Obliterate"
  ],
  "text": [
    "消灭一个随从。你的英雄受到等同于该随从生命值的\n伤害。",
    "Destroy a minion. Your hero takes damage equal to its Health."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43120
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t6 : SimCard //* Obliterate
    {
        // Destroy a minion. Your hero takes damage equal to its Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, target.Hp);
            p.minionGetDestroyed(target);
        }
    }
}