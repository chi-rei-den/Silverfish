using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_832pb",
  "name": [
    "蜘蛛毒牙",
    "Spider Fangs"
  ],
  "text": [
    "+3攻击力。",
    "+3 Attack."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 46051
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_832pb: SimTemplate //* Spider Fangs
    {
        // +3 Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.minionGetTempBuff(p.ownHero, 3, 0);
            else p.minionGetTempBuff(p.enemyHero, 3, 0);
        }
    }
}