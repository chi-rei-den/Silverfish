using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_609",
  "name": [
    "邪兽人噬魂魔",
    "Fel Orc Soulfiend"
  ],
  "text": [
    "在你的回合开始时，对该随从造成2点\n伤害。",
    "At the start of your turn, deal 2 damage to this minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40389
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_609 : SimCard //* Fel Orc Soulfiend
	{
		// At the start of your turn, deal 2 damage to this minion.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(triggerEffectMinion, 2);
            }
        }
    }
}