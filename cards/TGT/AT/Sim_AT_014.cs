using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_014",
  "name": [
    "暗影魔",
    "Shadowfiend"
  ],
  "text": [
    "每当你抽一张牌时，使其法力值消耗减少（1）点。",
    "Whenever you draw a card, reduce its Cost by (1)."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2566
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_014 : SimCard //* Shadowfiend
	{
		//Whenever you draw a card reduce its cost by (1)

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.anzOwnShadowfiend++;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnShadowfiend--;
        }
	}
}