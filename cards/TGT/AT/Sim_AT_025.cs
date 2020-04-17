using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_025",
  "name": [
    "黑暗交易",
    "Dark Bargain"
  ],
  "text": [
    "随机消灭两个敌方随从，随机弃两张牌。",
    "Destroy 2 random enemy minions. Discard 2 random cards."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2632
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_025 : SimCard //* Dark Bargain
	{
		//Destroy 2 random enemy minion. Discard 2 random cards.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
			if (temp.Count >= 2)
			{
				temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
				bool enough = false;
				foreach (Minion enemy in temp)
				{
					p.minionGetDestroyed(enemy);
					if (enough) break;
					enough = true;
				}
                p.discardCards(2, ownplay);
			}
		}
	}
}