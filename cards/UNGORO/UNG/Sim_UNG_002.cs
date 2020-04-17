using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_002",
  "name": [
    "火山龙",
    "Volcanosaur"
  ],
  "text": [
    "<b>战吼：</b>\n连续<b>进化</b>两次。",
    "<b>Battlecry:</b> <b>Adapt</b>, then <b>Adapt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41120
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_002 : SimCard //* Volcanosaur
	{
		//Battlecry: Adapt, then Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.getBestAdapt(own);
			p.getBestAdapt(own);
        }
    }
}