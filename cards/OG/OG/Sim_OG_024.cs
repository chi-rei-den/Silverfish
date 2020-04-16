using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_024",
  "name": [
    "投火无面者",
    "Flamewreathed Faceless"
  ],
  "text": [
    "<b>过载：</b>（2）",
    "<b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38263
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_024 : SimTemplate //* Flamewreathed Faceless
	{
		//Overload: (2)
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.ueberladung += 2;
		}
	}
}