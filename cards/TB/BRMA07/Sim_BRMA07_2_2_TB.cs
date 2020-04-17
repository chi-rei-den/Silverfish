using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA07_2_2_TB",
  "name": [
    "猛砸",
    "ME SMASH"
  ],
  "text": [
    "<b>英雄技能</b>\n随机消灭一个敌方随从。",
    "<b>Hero Power</b>\nDestroy a random enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 30350
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA07_2_2_TB : SimCard //* ME SMASH
	{
		// Hero Power: Destroy a random damaged enemy minion
				
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			List<Minion> temp = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
            foreach (Minion m in temp)
            {
				if(m.wounded)
				{
					p.minionGetDestroyed(m);
					break;
				}
            }
		}
	}
}