using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_623",
  "name": [
    "圣殿执行者",
    "Temple Enforcer"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+3生命值。",
    "<b>Battlecry:</b> Give a friendly minion +3 Health."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1364
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_623 : SimCard //templeenforcer
	{

//    kampfschrei:/ verleiht einem befreundeten diener +3 leben.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetBuffed(target, 0, 3);
		}

	}
}