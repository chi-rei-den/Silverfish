using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_851",
  "name": [
    "勇敢的记者",
    "Daring Reporter"
  ],
  "text": [
    "每当你的对手抽一张牌时，便获得+1/+1。",
    "Whenever your opponent draws a card, gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40741
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_851 : SimTemplate //* Daring Reporter
	{
		// Whenever your opponent draws a card, gain +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
	}
}