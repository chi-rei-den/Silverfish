using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_320",
  "name": [
    "午夜噩龙",
    "Midnight Drake"
  ],
  "text": [
    "<b>战吼：</b>你每有一张其它手牌，便获得+1攻击力。",
    "<b>Battlecry:</b> Gain +1 Attack for each other card\nin your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38957
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_320 : SimCard //* Midnight Drake
	{
		// Battlecry: Gain +1 attack for each other card in your hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetBuffed(own, (own.own) ? p.owncards.Count : p.enemyAnzCards, 0);
		}
	}
}