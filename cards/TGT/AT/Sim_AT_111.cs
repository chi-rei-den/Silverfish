using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_111",
  "name": [
    "零食商贩",
    "Refreshment Vendor"
  ],
  "text": [
    "<b>战吼：</b>为每个英雄恢复#4点生命值。",
    "<b>Battlecry:</b> Restore #4 Health to each hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2704
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_111 : SimCard //* Refreshment Vendor
	{
		//Battlecry: Restore 4 Health to each hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(p.ownHero, -heal);
            p.minionGetDamageOrHeal(p.enemyHero, -heal);
        }
    }
}