using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_655",
  "name": [
    "毒性污水软泥怪",
    "Toxic Sewer Ooze"
  ],
  "text": [
    "<b>战吼：</b>使对手的武器失去1点耐久度。",
    "<b>Battlecry:</b> Remove 1 Durability from your opponent's weapon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40921
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_655 : SimCard //* Toxic Sewer Ooze
	{
		// Battlecry: Remove 1 Durability from your opponent's weapon.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.lowerWeaponDurability(1, !m.own);
        }
    }
}