using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_158",
  "name": [
    "丛林之魂",
    "Soul of the Forest"
  ],
  "text": [
    "使你的所有随从获得“<b>亡语：</b>召唤一个2/2的树人”。",
    "Give your minions \"<b>Deathrattle:</b> Summon a 2/2 Treant.\""
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 381
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_158 : SimCard //souloftheforest
	{

//    verleiht euren dienern „todesröcheln:/ ruft einen treant (2/2) herbei.“

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                m.souloftheforest++;
            }
		}

	}
}