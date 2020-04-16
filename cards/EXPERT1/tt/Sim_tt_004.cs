using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "tt_004",
  "name": [
    "腐肉食尸鬼",
    "Flesheating Ghoul"
  ],
  "text": [
    "每当一个随从死亡，便获得+1攻击力。",
    "Whenever a minion dies, gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 397
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_tt_004 : SimTemplate //* flesheatingghoul
	{
//    Whenever a minion dies, gain +1 Attack.

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            if (residual >= 1)
            {
                p.minionGetBuffed(m, residual, 0);
            }
        }
	}
}