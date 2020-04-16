using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_030",
  "name": [
    "幽暗城勇士",
    "Undercity Valiant"
  ],
  "text": [
    "<b>连击：</b>造成1点伤害。",
    "<b>Combo:</b> Deal 1 damage."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2767
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_030 : SimTemplate //* Undercity Valiant
	{
		//Combo: deal 1 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null)
            {
                p.minionGetDamageOrHeal(target, 1);
            }
		}
	}
}