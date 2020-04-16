using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_084",
  "name": [
    "火羽凤凰",
    "Fire Plume Phoenix"
  ],
  "text": [
    "<b>战吼：</b>造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41260
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_084 : SimTemplate //* Fire Plume Phoenix
	{
		//Battlecry: Deal 2 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetDamageOrHeal(target, 2);
		}
	}
}