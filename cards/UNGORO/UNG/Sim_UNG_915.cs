using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_915",
  "name": [
    "雷鸣刺喉龙",
    "Crackling Razormaw"
  ],
  "text": [
    "<b>战吼：</b><b>进化</b>一个友方野兽。",
    "<b>Battlecry:</b> <b>Adapt</b> a friendly Beast."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41358
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_915 : SimTemplate //* Crackling Razormaw
	{
		//Battlecry: Adapt a friendly Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null) p.getBestAdapt(own);
        }
    }
}