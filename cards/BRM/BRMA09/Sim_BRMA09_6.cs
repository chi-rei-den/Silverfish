using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA09_6",
  "name": [
    "真正的酋长",
    "The True Warchief"
  ],
  "text": [
    "消灭一个传说随从",
    "Destroy a Legendary minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2353
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA09_6 : SimCard //* The True Warchief
    {
        // Destroy a Legendary minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			if (target != null) p.minionGetDestroyed(target);
        }
    }
}