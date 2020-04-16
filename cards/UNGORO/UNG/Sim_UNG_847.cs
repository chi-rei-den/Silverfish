using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_847",
  "name": [
    "火焰使者",
    "Blazecaller"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，则造成5点伤害。",
    "<b>Battlecry:</b> If you played an Elemental last turn, deal 5 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41928
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_847 : SimTemplate //* Blazecaller
	{
		//Battlecry: If you played an Elemental last turn, deal 5 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetDamageOrHeal(target, 5);
		}
	}
}