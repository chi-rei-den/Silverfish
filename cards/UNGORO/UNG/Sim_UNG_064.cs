using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_064",
  "name": [
    "邪脊吞噬者",
    "Vilespine Slayer"
  ],
  "text": [
    "<b>连击：</b>\n消灭一个随从。",
    "<b>Combo:</b> Destroy a minion."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41217
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_064 : SimCard //* Vilespine Slayer
	{
		//Combo: Destroy a minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null && own.own)
            {
                p.minionGetDestroyed(target);
            }
		}
	}
}