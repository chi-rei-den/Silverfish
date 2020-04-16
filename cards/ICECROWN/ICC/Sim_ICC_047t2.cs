using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_047t2",
  "name": [
    "命运织网蛛",
    "Fatespinner"
  ],
  "text": [
    "<b>亡语：</b>对所有随从造成3点伤害，并使所有随从获得+2/+2。",
    "<b>Deathrattle:</b> Deal 3 damage to all minions and give them +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43431
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_047t2 : SimTemplate //* Fatespinner on board 2x
    {
        // Deathrattle: Give all minions +2/+2, then deal 3 damage to them.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetBuffed(true, 2, 2);
            p.allMinionOfASideGetBuffed(false, 2, 2);
            p.allMinionsGetDamage(3);
        }
    }
}