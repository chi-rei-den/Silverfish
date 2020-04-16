using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_047t",
  "name": [
    "命运织网蛛",
    "Fatespinner"
  ],
  "text": [
    "<b>秘密亡语：</b>对所有随从造成3点伤害；\n或者使所有随从获得+2/+2。@<b>秘密亡语：</b>使所有随从获得+2/+2。@<b>秘密亡语：</b>对所有随从造成3点伤害。",
    "<b>Secret Deathrattle:</b> Deal 3 damage to all minions; or Give them +2/+2.@<b>Secret Deathrattle:</b> Give +2/+2 to all minions.@<b>Secret Deathrattle:</b> Deal 3 damage to all minions."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43430
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_047t : SimTemplate //* Fatespinner on board
    {
        // Choose a Deathrattle (Secretly) - Deal 3 damage to all minions; or Give them +2/+2.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (m.hChoice == 1)
                {
                    p.allMinionOfASideGetBuffed(true, 2, 2);
                    p.allMinionOfASideGetBuffed(false, 2, 2);
                }
                else if (m.hChoice == 2) p.allMinionsGetDamage(3);
            }
            else if (!m.silenced)
            {
                if (p.prozis.enemyMinions.Count > p.prozis.ownMinions.Count)
                {
                    p.allMinionOfASideGetBuffed(false, 2, 2);
                }
                else p.allMinionsGetDamage(3);
            }
        }
    }
}