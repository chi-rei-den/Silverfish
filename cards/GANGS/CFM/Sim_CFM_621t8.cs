using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t8",
  "name": [
    "皇血草",
    "Kingsblood"
  ],
  "text": [
    "抽一张牌。",
    "Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41584
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t8 : SimTemplate //* Kingsblood
	{
		// Draw a card.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(SimCard.None, ownplay);
		}
	}
}