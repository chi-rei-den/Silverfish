using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_188",
  "name": [
    "卡拉克西织珀者",
    "Klaxxi Amber-Weaver"
  ],
  "text": [
    "<b>战吼：</b>\n如果你的克苏恩至少具有10点攻击力，便获得+5生命值。",
    "<b>Battlecry:</b> If your C'Thun has at least 10 Attack, gain +5 Health."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38621
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_188 : SimTemplate //* Klaxxi Amber-Weaver
	{
		//Battlecry: If your C'Thun has at least 10 Attack, gain +5 Health.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.minionGetBuffed(own, 0, 5);
                else p.evaluatePenality += 5;
            }
		}
	}
}