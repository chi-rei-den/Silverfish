using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_134",
  "name": [
    "军情七处特工",
    "SI:7 Agent"
  ],
  "text": [
    "<b>连击：</b>造成2点伤害。",
    "<b>Combo:</b> Deal 2 damage."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1117
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_134 : SimCard //* si7agent
	{
        // Combo:: Deal 2 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null)
            {
                p.minionGetDamageOrHeal(target, 2);
            }
		}
	}
}