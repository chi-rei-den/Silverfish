using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_928",
  "name": [
    "焦油爬行者",
    "Tar Creeper"
  ],
  "text": [
    "<b>嘲讽</b>\n在你对手的回合获得+2攻击力。",
    "<b>Taunt</b>\nHas +2 Attack during your opponent's turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41418
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_928 : SimCard //* Tar Creeper
	{
		//Taunt. Has +2 Attack during your opponent's turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, -2, 0);
            }
        }
    }
}