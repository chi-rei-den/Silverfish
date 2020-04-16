using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_234",
  "name": [
    "夜色镇炼金师",
    "Darkshire Alchemist"
  ],
  "text": [
    "<b>战吼：</b>\n恢复#5点生命值。",
    "<b>Battlecry:</b> Restore #5 Health."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38764
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_234 : SimTemplate //* Darkshire Alchemist
	{
		//Battlecry: Restore 5 Health.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
        }
    }
}