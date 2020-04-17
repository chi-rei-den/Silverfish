using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_659",
  "name": [
    "加基森名媛",
    "Gadgetzan Socialite"
  ],
  "text": [
    "<b>战吼：</b>\n恢复#2点生命值。",
    "<b>Battlecry:</b> Restore #2 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40949
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_659 : SimCard //* Gadgetzan Socialite
	{
		// Battlecry: Restore 2 Health.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                int heal = (m.own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
                p.minionGetDamageOrHeal(target, -heal);
            }
        }
    }
}