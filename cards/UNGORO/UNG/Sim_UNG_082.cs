using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_082",
  "name": [
    "雷霆蜥蜴",
    "Thunder Lizard"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，则获得<b>进化</b>。",
    "<b>Battlecry</b>: If you played an Elemental last turn, <b>Adapt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41257
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_082 : SimCard //* Thunder Lizard
	{
		//Battlecry: If you played an Elemental last turn, Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own) p.getBestAdapt(own);
        }
    }
}