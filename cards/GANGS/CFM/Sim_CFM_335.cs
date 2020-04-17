using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_335",
  "name": [
    "驮运科多兽",
    "Dispatch Kodo"
  ],
  "text": [
    "<b>战吼：</b>造成等同于该随从攻击力的伤害。",
    "<b>Battlecry:</b> Deal damage equal to this minion's Attack."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 41126
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_335 : SimCard //* Dispatch Kodo
	{
        // Battlecry: Deal damage equal to this minion's Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDamageOrHeal(target, m.Angr);
        }
	}
}