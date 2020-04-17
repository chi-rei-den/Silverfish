using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_049",
  "name": [
    "焦油潜伏者",
    "Tar Lurker"
  ],
  "text": [
    "<b>嘲讽</b>\n在你对手的回合获得+3攻击力。",
    "<b>Taunt</b>\nHas +3 Attack during your opponent's turn."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41194
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_049 : SimCard //* Tar Lurker
	{
		//Taunt. Has +3 Attack during your opponent's turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 3, 0);
            }
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, -3, 0);
            }
        }
    }
}