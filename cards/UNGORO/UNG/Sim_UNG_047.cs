using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_047",
  "name": [
    "饥饿的翼手龙",
    "Ravenous Pterrordax"
  ],
  "text": [
    "<b>战吼：</b>\n消灭一个友方随从，并连续<b>进化</b>两次。",
    "<b>Battlecry:</b> Destroy a friendly minion to <b>Adapt</b> twice."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41191
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_047 : SimTemplate //* Ravenous Pterrordax
	{
		//Battlecry: Destroy a friendly minion to Adapt twice.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null)
			{
				p.minionGetDestroyed(target);
				p.getBestAdapt(own);
				p.getBestAdapt(own);
			}
        }
    }
}