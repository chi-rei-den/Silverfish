using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_018",
  "name": [
    "银色神官帕尔崔丝",
    "Confessor Paletress"
  ],
  "text": [
    "<b>激励：</b>随机召唤一个<b>传说</b>随从。",
    "<b>Inspire:</b> Summon a random <b>Legendary</b> minion."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2556
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_018 : SimTemplate //* Confessor Paletress
	{
		//Inspire: Summon a random Legendary minion.

		Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Neutral.KingMukla;//King Mukla 5/5
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{				
				p.callKid(kid, m.zonepos, m.own);
			}
        }
	}
}