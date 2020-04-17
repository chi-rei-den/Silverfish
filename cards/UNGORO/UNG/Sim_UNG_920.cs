using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_920",
  "name": [
    "湿地女王",
    "The Marsh Queen"
  ],
  "text": [
    "<b>任务：</b>使用七张法力值消耗为（1）的随从牌。\n<b>奖励：</b>卡纳莎女王。",
    "[x]<b>Quest:</b> Play seven\n1-Cost minions.\n<b>Reward:</b> Queen Carnassa."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41368
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_920 : SimCard //* The Marsh Queen
	{
		//Quest: Play seven 1-Cost minions. Reward: Queen Carnassa.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}