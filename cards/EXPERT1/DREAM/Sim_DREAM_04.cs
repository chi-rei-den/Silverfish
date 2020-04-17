using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DREAM_04",
  "name": [
    "梦境",
    "Dream"
  ],
  "text": [
    "将一个随从移回其拥有者的\n手牌。",
    "Return a minion to its owner's hand."
  ],
  "cardClass": "DREAM",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 808
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DREAM_04 : SimCard //dream
	{

//    lasst einen diener auf die hand seines besitzers zurückkehren.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, target.own, 0);
		}


	}
}