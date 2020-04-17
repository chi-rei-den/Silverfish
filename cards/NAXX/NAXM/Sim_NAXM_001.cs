using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAXM_001",
  "name": [
    "死灵骑士",
    "Necroknight"
  ],
  "text": [
    "<b>亡语：</b>消灭与该随从相邻的随从。",
    "<b>Deathrattle:</b> Destroy the minions next to this one as well."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1788
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAXM_001 : SimCard //* Necroknight
	{
	//    Deathrattle: Destroy the minions next to this one as well.

		public override void onDeathrattle(Playfield p, Minion m)
		{
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.zonepos == m.zonepos + 1 || mnn.zonepos + 1 == m.zonepos)
                {
					p.minionGetDestroyed(mnn);
                }

            }
		}
	}
}