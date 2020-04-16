using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_031",
  "name": [
    "暗夜嗥狼",
    "Night Howler"
  ],
  "text": [
    "每当该随从受到伤害，便获得\n+2攻击力。",
    "Whenever this minion takes\ndamage, gain +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42445
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_031: SimTemplate //* Night Howler
    {
        // Whenever this minion takes damage, gain +2 Attack.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
                    p.minionGetBuffed(m, 2, 0);
                }
            }
        }
    }
}