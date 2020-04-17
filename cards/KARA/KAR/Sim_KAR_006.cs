using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_006",
  "name": [
    "神秘女猎手",
    "Cloaked Huntress"
  ],
  "text": [
    "你的<b>奥秘</b>法力值消耗为（0）点。",
    "Your <b>Secrets</b> cost (0)."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39492
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_006 : SimCard //* Cloaked Huntress
	{
		//Your Secrets cost (0).

		public override void onAuraStarts(Playfield p, Minion m)
		{
            if (m.own) p.anzOwnCloakedHuntress++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnCloakedHuntress--;
        }
	}
}