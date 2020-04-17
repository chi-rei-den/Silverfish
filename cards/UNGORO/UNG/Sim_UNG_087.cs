using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_087",
  "name": [
    "苦潮多头蛇",
    "Bittertide Hydra"
  ],
  "text": [
    "每当该随从受到伤害，对你的英雄造成\n3点伤害。",
    "Whenever this minion takes damage, deal 3 damage to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41263
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_087 : SimCard //* Bittertide Hydra
	{
		//Whenever this minion takes damage, deal 3 damage to your hero.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                m.anzGotDmg = 0;
				p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, 3);
            }
        }
	}
}