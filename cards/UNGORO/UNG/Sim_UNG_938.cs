using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_938",
  "name": [
    "温泉守卫",
    "Hot Spring Guardian"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>\n恢复#3点生命值。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Restore #3 Health."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41479
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_938 : SimTemplate //* Hot Spring Guardian
	{
		//Taunt. Battlecry: Restore 3 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null)
			{
				int heal = (own.own) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
				p.minionGetDamageOrHeal(target, -heal);
			}
        }
    }
}