using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_028t",
  "name": [
    "时空扭曲",
    "Time Warp"
  ],
  "text": [
    "获得一个额外回合。",
    "Take an extra turn."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41167
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_028t : SimTemplate //* Time Warp
	{
		//Take an extra turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.ownMinions.Count > 3) p.evaluatePenality += 100;
                else if (p.ownMinions.Count > 2) p.evaluatePenality += 50;
                else if (p.ownMinions.Count > 1) p.evaluatePenality += 20;
                if (p.nextTurnWin()) p.evaluatePenality += 500;
            }
        }
    }
}