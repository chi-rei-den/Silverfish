using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX6_03t",
  "name": [
    "孢子",
    "Spore"
  ],
  "text": [
    "<b>亡语：</b>使所有敌方随从获得+8攻击力。",
    "<b>Deathrattle:</b> Give all enemy minions +8 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1865
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX6_03t : SimCard //* Spore
	{
//    Deathrattle: Give all enemy minions +8 Attack.

        public override void onDeathrattle(Playfield p, Minion m)
		{
			List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
            foreach (Minion mm in temp)
            {
                p.minionGetBuffed(mm, 8, 0);
            }
		}
	}
}