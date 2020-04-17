using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_009",
  "name": [
    "暴掠龙幼崽",
    "Ravasaur Runt"
  ],
  "text": [
    "<b>战吼：</b>如果你控制至少两个其他随从，便获得<b>进化</b>。",
    "<b>Battlecry:</b> If you control at least 2 other minions, <b>Adapt.</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41137
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_009 : SimCard //* Ravasaur Runt
	{
		//Battlecry: If you control at least 2 other minions, Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int num = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
			if (num > 1) p.getBestAdapt(own);
        }
    }
}