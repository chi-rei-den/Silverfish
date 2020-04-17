using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_005",
  "name": [
    "劫持者",
    "Kidnapper"
  ],
  "text": [
    "<b>连击：</b>将一个随从移回其拥有者的手牌。",
    "<b>Combo:</b> Return a minion to its owner's hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 287
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_005 : SimCard //kidnapper
	{

//    combo:/ lasst einen diener auf die hand seines besitzers zurückkehren.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1) p.minionReturnToHand(target,target.own, 0);
		}


	}
}