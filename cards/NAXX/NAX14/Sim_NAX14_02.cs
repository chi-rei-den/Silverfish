using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX14_02",
  "name": [
    "冰霜吐息",
    "Frost Breath"
  ],
  "text": [
    "<b>英雄技能</b>\n消灭所有没有被<b>冻结</b>的敌方随从。",
    "<b>Hero Power</b>\nDestroy all enemy minions that aren't <b>Frozen</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1905
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX14_02 : SimTemplate //* Frost Breath
	{
		// Hero PowerDestroy all enemy minions that aren't Frozen.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = ownplay ? p.enemyMinions : p.ownMinions;
            int i = 0;
			int tempCount = temp.Count;
            for (; i < tempCount; i++)
            {
				temp[i].extraParam = true;
                if (temp[i].frozen) temp[i].extraParam = false;
                if (temp[i].name == CardIds.NonCollectible.Neutral.FrozenChampion && !temp[i].silenced)
				{
					temp[i].extraParam = false;
					if (i > 0) temp[i-1].extraParam = false;
					if (i + 1 < tempCount) temp[i+1].extraParam = false;
				}
            }
			
            foreach (Minion m in temp)
            {
                if (!m.extraParam) continue;
				m.extraParam = false;
				p.minionGetDestroyed(m);
            }
		}
	}
}