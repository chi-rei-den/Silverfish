using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_399",
  "name": [
    "古拉巴什狂暴者",
    "Gurubashi Berserker"
  ],
  "text": [
    "每当该随从受到伤害，便获得\n+3攻击力。",
    "Whenever this minion takes damage, gain +3 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 768
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_399 : SimCard //* gurubashiberserker
	{
    // Whenever this minion takes damage, gain +3 Attack.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
					p.minionGetBuffed(m, 3, 0);
                }
            }
        }
	}
}