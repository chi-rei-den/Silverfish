using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_925",
  "name": [
    "暴躁的恐角龙",
    "Ornery Direhorn"
  ],
  "text": [
    "<b>嘲讽，战吼：</b><b>进化</b>。",
    "<b>Taunt</b>\n<b>Battlecry:</b> <b>Adapt</b>."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41404
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_925 : SimCard //* Ornery Direhorn
	{
		//Taunt. Battlecry: Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own) p.getBestAdapt(own);
        }
    }
}