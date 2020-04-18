using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_113",
  "name": [
    "征募官",
    "Recruiter"
  ],
  "text": [
    "<b>激励：</b>将一个2/2的侍从置入你的手牌。",
    "<b>Inspire:</b> Add a 2/2 Squire to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2509
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_113 : SimTemplate //* Recruiter
	{
		//Inspire: Add a 2/2 Squire to your hand.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{				
				p.drawACard(Chireiden.Silverfish.SimCard.squire, own, true);
			}
        }
	}
}