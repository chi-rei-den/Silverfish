using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_084",
  "name": [
    "持枪侍从",
    "Lance Carrier"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+2攻击力。",
    "<b>Battlecry:</b> Give a friendly minion +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2577
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_084 : SimTemplate //* Lance Carrier
	{
		//Battlecry: Give a friendly minion +2 Attack.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetBuffed(target, 2, 0);
		}
	}
}