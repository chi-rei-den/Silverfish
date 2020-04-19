using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_031",
  "name": [
    "克洛玛古斯",
    "Chromaggus"
  ],
  "text": [
    "每当你抽一张牌时，将该牌的另一张复制置入你的手牌。",
    "Whenever you draw a card, put another copy into your hand."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2280
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_031 : SimTemplate //* Chromaggus
	{
		// Whenever you draw a card, put another copy into your hand.
		
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnChromaggus++;
            else p.anzEnemyChromaggus++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnChromaggus--;
            else p.anzEnemyChromaggus--;
        }
	}
}
