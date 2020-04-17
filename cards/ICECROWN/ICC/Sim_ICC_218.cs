using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_218",
  "name": [
    "咆哮魔",
    "Howlfiend"
  ],
  "text": [
    "每当该随从受到伤害，随机弃掉\n一张牌。",
    "Whenever this minion takes damage, discard a random card."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42642
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_218: SimCard //* Howlfiend
    {
        // Whenever this minion takes damage, discard a random card.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0) p.discardCards(m.anzGotDmg, m.own);
        }
    }
}
