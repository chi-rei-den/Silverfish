using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_001",
  "name": [
    "翼手龙宝宝",
    "Pterrordax Hatchling"
  ],
  "text": [
    "<b>战吼：</b><b>进化</b>。",
    "<b><b>Battlecry:</b> Adapt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41076
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_001 : SimTemplate //* Pterrordax Hatchling
	{
		//Battlecry: Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.getBestAdapt(own);
        }
    }
}