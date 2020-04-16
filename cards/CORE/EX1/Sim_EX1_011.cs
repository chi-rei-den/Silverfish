using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_011",
  "name": [
    "巫医",
    "Voodoo Doctor"
  ],
  "text": [
    "<b>战吼：</b>\n恢复#2点生命值。",
    "<b>Battlecry:</b> Restore #2 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 132
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_011 : SimTemplate //voodoodoctor
	{

//    kampfschrei:/ stellt 2 leben wieder her.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int heal = (own.own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
            p.minionGetDamageOrHeal(target, -heal);
		}


	}
}