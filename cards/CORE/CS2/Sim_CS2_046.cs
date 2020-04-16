using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_046",
  "name": [
    "嗜血",
    "Bloodlust"
  ],
  "text": [
    "在本回合中，使你的所有随从获得+3攻击力。",
    "Give your minions +3 Attack this turn."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1171
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_046 : SimTemplate //bloodlust
	{

//    verleiht euren dienern +3 angriff in diesem zug.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions: p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetTempBuff(m, 3, 0);
            }
		}

	}
}