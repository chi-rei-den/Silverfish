using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_099",
  "name": [
    "狂奔的魔暴龙",
    "Charged Devilsaur"
  ],
  "text": [
    "<b>冲锋，战吼：</b>在本回合中无法攻击英雄。",
    "<b>Charge</b>\n<b>Battlecry:</b> Can't attack heroes this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41286
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_099 : SimCard //* Charged Devilsaur
	{
		//Charge Battlecry: Can't attack heroes this turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.cantAttackHeroes = true;
		}

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner) triggerEffectMinion.cantAttackHeroes = false;
        }
    }
}