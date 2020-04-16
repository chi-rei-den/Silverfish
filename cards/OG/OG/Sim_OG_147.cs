using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_147",
  "name": [
    "腐化治疗机器人",
    "Corrupted Healbot"
  ],
  "text": [
    "<b>亡语：</b>为敌方英雄恢复#8点生命值。",
    "<b>Deathrattle:</b> Restore #8 Health to the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38528
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_147 : SimTemplate //* Corrupted Healbot
	{
		//Deathrattle: Restore 8 Health to the enemy hero.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int heal = (m.own) ? p.getMinionHeal(8) : p.getEnemyMinionHeal(8);

            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, -heal);
        }
    }
}