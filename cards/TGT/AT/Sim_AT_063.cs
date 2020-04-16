using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_063",
  "name": [
    "酸喉",
    "Acidmaw"
  ],
  "text": [
    "每当有其他随从受到伤害，将其消灭。",
    "Whenever another minion takes damage, destroy it."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2633
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_063 : SimTemplate //* Acidmaw
	{
		//Whenever another minion takes damage, destroy it.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.anzAcidmaw++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.anzAcidmaw--;
		}
	}
}