using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_646",
  "name": [
    "后街男巫",
    "Backstreet Leper"
  ],
  "text": [
    "<b>亡语：</b>对敌方英雄造成2点伤害。",
    "[x]<b>Deathrattle:</b> Deal 2 damage\nto the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40492
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_646 : SimTemplate //* Backstreet Leper
	{
		// Deathrattle: Deal 2 damage to the enemy hero.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
        }
    }
}