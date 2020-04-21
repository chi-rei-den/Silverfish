using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t5",
  "name": [
    "冰盖草",
    "Icecap"
  ],
  "text": [
    "随机<b>冻结</b>一个敌方随从。",
    "<b>Freeze</b> a random enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41587
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t5 : SimTemplate //* Icecap
	{
		// Freeze: a random enemy minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
			if (temp.Count > 0)
			{
				target = p.searchRandomMinion(temp, SearchMode.LowHealth);
                if (target != null) p.minionGetFrozen(target);
			}
        }
    }
}