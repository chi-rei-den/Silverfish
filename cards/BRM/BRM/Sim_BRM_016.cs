using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_016",
  "name": [
    "掷斧者",
    "Axe Flinger"
  ],
  "text": [
    "每当该随从受到伤害，对敌方英雄造成\n2点伤害。",
    "Whenever this minion takes damage, deal 2 damage to the enemy hero."
  ],
  "CardClass": "WARRIOR",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2297
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_016 : SimTemplate //* Axe Flinger
	{
		// Whenever this minion takes damage, deal 2 damage to the enemy hero

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
					p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
                }
            }
        }
	}
}