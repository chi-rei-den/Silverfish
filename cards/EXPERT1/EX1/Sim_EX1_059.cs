using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_059",
  "name": [
    "疯狂的炼金师",
    "Crazed Alchemist"
  ],
  "text": [
    "<b>战吼：</b>\n使一个随从的攻击力和生命值互换。",
    "<b>Battlecry:</b> Swap the Attack and Health of a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 801
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_059 : SimTemplate //* Crazed Alchemist
	{
        // Battlecry: Swap the Attack and Health of a minion.

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            if (target != null) p.minionSwapAngrAndHP(target);
		}
	}
}