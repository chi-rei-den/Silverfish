using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_116",
  "name": [
    "丛林巨兽",
    "Jungle Giants"
  ],
  "text": [
    "<b>任务：</b>召唤5个攻击力大于或等于5的随从。\n<b>奖励：</b>班纳布斯。",
    "[x]<b>Quest:</b> Summon\n5 minions with\n5 or more Attack.\n<b>Reward:</b> Barnabus."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41099
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_116 : SimCard //* Jungle Giants
	{
		//Quest: Summon 5 minions with 5 or more Attack. Reward: Barnabus.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}