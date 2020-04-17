using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t10",
  "name": [
    "氤氲迷雾",
    "Shrouding Mist"
  ],
  "text": [
    "获得<b>潜行</b>直到你的下个回合。",
    "<b>Stealth</b> until your next turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41054
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t10 : SimCard //* Shrouding Mist
	{
		//Stealth until your next turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.stealth = true;
            target.conceal = true;
        }
    }
}