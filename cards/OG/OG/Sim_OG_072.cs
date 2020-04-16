using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_072",
  "name": [
    "深渊探险",
    "Journey Below"
  ],
  "text": [
    "<b>发现</b>一张<b>亡语</b>牌。",
    "<b>Discover</b> a <b>Deathrattle</b> card."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38393
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_072 : SimTemplate //* Journey Below
	{
		//Discover a Deathrattle card
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.lepergnome, ownplay, true);
		}
	}
}