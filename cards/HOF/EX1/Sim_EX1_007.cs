using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_007",
  "name": [
    "苦痛侍僧",
    "Acolyte of Pain"
  ],
  "text": [
    "每当该随从受到伤害，抽一张牌。",
    "Whenever this minion takes damage, draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1659
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_007 : SimTemplate//* Acolyte of Pain
    {
        // Whenever this minion takes damage, draw a card.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
                    p.drawACard(SimCard.None, m.own);
                }
            }
        }
    }
}
