using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_026",
  "name": [
    "愤怒卫士",
    "Wrathguard"
  ],
  "text": [
    "每当该随从受到伤害，对你的英雄造成等量的伤害。",
    "Whenever this minion takes damage, also deal that amount to your hero."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2623
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_026 : SimCard //* Wrathguard
	{
		//Whenever this minion takes damage, also deal that amount to your hero.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                m.anzGotDmg = 0;
				p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, m.GotDmgValue);
            }
        }
	}
}