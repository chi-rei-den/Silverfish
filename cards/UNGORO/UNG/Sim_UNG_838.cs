using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_838",
  "name": [
    "焦油兽王",
    "Tar Lord"
  ],
  "text": [
    "<b>嘲讽</b>\n在你对手的回合获得+4攻击力。",
    "<b>Taunt</b>\nHas +4 Attack during your opponent’s turn."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 7,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41881
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_838 : SimTemplate //* Tar Lord
	{
		//Taunt. Has +4 Attack during your opponent’s turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 4, 0);
            }
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, -4, 0);
            }
        }
    }
}