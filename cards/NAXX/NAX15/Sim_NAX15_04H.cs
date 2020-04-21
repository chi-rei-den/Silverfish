using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX15_04H",
  "name": [
    "锁链",
    "Chains"
  ],
  "text": [
    "<b>英雄技能</b>\n随机获得一个敌方随从的控制权。",
    "<b>Hero Power</b>\nTake control of a random enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 8,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2149
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX15_04H : SimTemplate //* Chains
	{
		// Hero Power: Take control of a random enemy minion.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
            if (temp.Count <= 0) return;
            Minion m = p.searchRandomMinion(temp, SearchMode.LowHealth);
            if (m != null) p.minionGetControlled(m, ownplay, false);
		}
	}
}