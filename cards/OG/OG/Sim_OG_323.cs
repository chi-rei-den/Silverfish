using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_323",
  "name": [
    "被感染的贮藏者",
    "Polluted Hoarder"
  ],
  "text": [
    "<b>亡语：</b>抽一张牌。",
    "<b>Deathrattle:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38961
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_323 : SimTemplate //* Polluted Hoarder
	{
		//Deathrattle: Draw a card.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, m.own);
        }
    }
}