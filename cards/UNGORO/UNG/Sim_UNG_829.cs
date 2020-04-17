using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_829",
  "name": [
    "拉卡利献祭",
    "Lakkari Sacrifice"
  ],
  "text": [
    "<b>任务：</b>弃掉六张牌。\n<b>奖励：</b>虚空传送门。",
    "[x]<b>Quest:</b> Discard 6 cards.\n<b>Reward:</b> Nether Portal."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41856
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_829 : SimCard //* Lakkari Sacrifice
	{
		//Quest: Discard 6 cards. Reward: Nether Portal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}