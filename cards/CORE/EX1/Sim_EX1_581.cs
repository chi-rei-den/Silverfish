using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_581",
  "name": [
    "闷棍",
    "Sap"
  ],
  "text": [
    "将一个敌方随从移回你对手的\n手牌。",
    "Return an enemy minion to your opponent's hand."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 461
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_581 : SimTemplate //sap
	{

//    lasst einen feindlichen diener auf die hand eures gegners zurückkehren.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, !ownplay, 0);
		}

	}
}