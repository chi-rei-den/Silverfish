using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_109",
  "name": [
    "年迈的长颈龙",
    "Elder Longneck"
  ],
  "text": [
    "<b>战吼：</b>\n如果你的手牌中有攻击力大于或等于5的随从牌，便获得<b>进化</b>。",
    "<b>Battlecry:</b> If you're holding a minion with 5 or more Attack, <b>Adapt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41086
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_109 : SimTemplate //* Elder Longneck
	{
		//Battlecry: If you're holding a minion with 5 or more Attack, Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if(own.own)
			{
				foreach (Handcard hc in p.owncards)
				{
					if ((hc.card.Attack + hc.addattack) >= 5)
					{
						p.getBestAdapt(own);
						break;
					}
				}
			}
        }
    }
}