using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_934",
  "name": [
    "火羽之心",
    "Fire Plume's Heart"
  ],
  "text": [
    "<b>任务：</b>使用七张具有<b>嘲讽</b>的随从牌。\n<b>奖励：</b>萨弗拉斯。",
    "[x]<b>Quest:</b> Play\n7 <b>Taunt</b> minions.\n<b>Reward:</b> Sulfuras."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41427
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_934 : SimCard //* Fire Plume's Heart
	{
		//Quest: Play 7 Taunt minions. Reward: Sulfuras.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}