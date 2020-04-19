using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_055",
  "name": [
    "暗鳞治愈者",
    "Darkscale Healer"
  ],
  "text": [
    "<b>战吼：</b>为所有友方角色恢复#2点生命值。",
    "<b>Battlecry:</b> Restore #2 Health to all friendly characters."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 582
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DS1_055 : SimTemplate //darkscalehealer
	{

//    kampfschrei:/ stellt bei allen befreundeten charakteren 2 leben wieder her.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int heal = (own.own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
            p.allCharsOfASideGetDamage(own.own, -heal);
		}


	}
}