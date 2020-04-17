using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_120",
  "name": [
    "亡灵药剂师",
    "Mistress of Mixtures"
  ],
  "text": [
    "<b>亡语：</b>为每个英雄恢复#4点生命值。",
    "<b>Deathrattle:</b> Restore #4 Health to each hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 41566
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_120 : SimCard //* Mistress of Mixtures
	{
		// Deathrattle: Restore 4 Health to both players.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int heal = (m.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(p.ownHero, -heal);
            p.minionGetDamageOrHeal(p.enemyHero, -heal);
        }
    }
}