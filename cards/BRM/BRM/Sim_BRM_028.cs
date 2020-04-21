using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_028",
  "name": [
    "索瑞森大帝",
    "Emperor Thaurissan"
  ],
  "text": [
    "在你的回合结束时，你所有手牌的法力值消耗减少（1）点。",
    "At the end of your turn, reduce the Cost of cards in your hand by (1)."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2262
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_028 : SimTemplate //* Emperor Thaurissan
	{
		// At the end of your turn, reduce the Cost of cards in your hand by (1).
		
        public override void onTurnEndsTrigger(Playfield p, Minion m, bool turnEndOfOwner)
        {
            if (m.own == turnEndOfOwner)
            {
				foreach (Handcard hc in p.owncards)
                {
                    if (hc.manacost >= 1) hc.manacost--;
                }
            }
        }
	}
}