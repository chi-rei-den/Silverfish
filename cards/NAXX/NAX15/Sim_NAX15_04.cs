using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX15_04",
  "name": [
    "锁链",
    "Chains"
  ],
  "text": [
    "<b>英雄技能</b>\n随机获得一个敌方随从的控制权，直到回合结束。",
    "<b>Hero Power</b>\nTake control of a random enemy minion until end of turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 8,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1904
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX15_04 : SimCard //* Chains
	{
		// Hero Power: Take control of a random enemy minion until end of turn.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count <= 0) return;
            Minion m = p.searchRandomMinion(temp, searchmode.searchLowestHP);
            if (m != null)
			{
				m.shadowmadnessed = true;
				p.shadowmadnessed++;
				p.minionGetControlled(m, ownplay, false);
			}
		}
	}
}