using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_335",
  "name": [
    "变幻之影",
    "Shifting Shade"
  ],
  "text": [
    "<b>亡语：</b>复制你对手的牌库中的一张牌，并将其置入你的手牌。",
    "[x]<b>Deathrattle:</b> Copy a card\nfrom your opponent's deck\n and add it to your hand."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 39034
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_335 : SimTemplate //* Shifting Shade
	{
		//Deathrattle: Copy a card from your opponent's deck and add it to your hand.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, m.own, true);
        }
	}
}