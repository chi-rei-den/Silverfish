using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_019",
  "name": [
    "剧毒之种",
    "Poison Seeds"
  ],
  "text": [
    "消灭所有随从，并召唤等量的2/2树人代替他们。",
    "Destroy all minions and summon 2/2 Treants to replace them."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1802
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_019 : SimCard //poisonseeds
	{
        CardDB.Card d = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);
//    vernichtet alle diener und ruft für jeden einen treant (2/2) als ersatz herbei.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int ownanz = p.ownMinions.Count;
            int enemanz = p.enemyMinions.Count;
            p.allMinionsGetDestroyed();
            for (int i = 0; i < ownanz; i++)
            {
                p.callKid(d, 1, true);
            }
            for (int i = 0; i < enemanz; i++)
            {
                p.callKid(d, 1, false);
            }
		}

	}
}