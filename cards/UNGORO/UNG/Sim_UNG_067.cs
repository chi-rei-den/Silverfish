using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_067",
  "name": [
    "探索地下洞穴",
    "The Caverns Below"
  ],
  "text": [
    "<b>任务：</b>使用五张名称相同的随从牌。\n<b>奖励：</b>水晶核心。",
    "[x]<b>Quest:</b> Play five minions\nwith the same name.\n<b>Reward:</b> Crystal Core."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41222
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_067 : SimCard //* The Caverns Below
	{
		//Quest: Play four minions with the same name. Reward: Crystal Core.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}