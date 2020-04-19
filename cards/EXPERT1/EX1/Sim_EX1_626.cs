using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_626",
  "name": [
    "群体驱散",
    "Mass Dispel"
  ],
  "text": [
    "<b>沉默</b>所有敌方随从，抽一张牌。",
    "<b>Silence</b> all enemy minions. Draw a card."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1366
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_626 : SimTemplate //massdispel
	{

//    bringt alle feindlichen diener zum schweigen/. zieht eine karte.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.allMinionsGetSilenced(!ownplay);
            p.drawACard(SimCard.None, ownplay);
		}

	}
}