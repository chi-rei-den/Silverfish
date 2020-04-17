using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_125",
  "name": [
    "冰吼",
    "Icehowl"
  ],
  "text": [
    "<b>冲锋</b>\n无法攻击英雄。",
    "<b>Charge</b>\nCan't attack heroes."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2725
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_125 : SimCard //* Icehowl
	{
		//Charge. Can't attack heroes.
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantAttackHeroes = true;
        }

        public override void onTurnEndsTrigger(Playfield p, Minion m, bool turnEndOfOwner)
        {
            if (m.own == turnEndOfOwner) m.cantAttackHeroes = true;
        }
    }
}