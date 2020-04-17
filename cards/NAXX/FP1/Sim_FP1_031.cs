using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_031",
  "name": [
    "瑞文戴尔男爵",
    "Baron Rivendare"
  ],
  "text": [
    "你的随从的<b>亡语</b>将触发两次。",
    "Your minions trigger their <b>Deathrattles</b> twice."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1915
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_031 : SimCard //baronrivendare
	{

//    die todesröcheln/-effekte eurer diener werden 2-mal ausgelöst.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.ownBaronRivendare++;
            else p.enemyBaronRivendare++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownBaronRivendare--;
            }
            else
            {
                p.enemyBaronRivendare--;
            }
        }

	}
}