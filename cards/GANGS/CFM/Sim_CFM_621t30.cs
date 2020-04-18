using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t30",
  "name": [
    "皇血草",
    "Kingsblood"
  ],
  "text": [
    "抽三张牌。",
    "Draw 3 cards."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41626
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t30 : SimTemplate //* Kingsblood
	{
		// Draw 3 cards.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
		}
	}
}