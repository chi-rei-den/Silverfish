using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_940",
  "name": [
    "唤醒造物者",
    "Awaken the Makers"
  ],
  "text": [
    "<b>任务：</b>召唤7个具有<b>亡语</b>的随从。\n<b>奖励：</b>希望守护者阿玛拉。",
    "<b>Quest:</b> Summon\n7 <b>Deathrattle</b> minions.<b>\nReward:</b> Amara, Warden of Hope."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41494
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_940 : SimTemplate //* Awaken the Makers
	{
		//Quest: Summon 7 Deathrattle minions. Reward: Amara, Warden of Hope.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}