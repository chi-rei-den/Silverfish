using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_565",
  "name": [
    "火舌图腾",
    "Flametongue Totem"
  ],
  "text": [
    "相邻的随从获得+2攻击力。",
    "Adjacent minions have +2 Attack."
  ],
  "CardClass": "SHAMAN",
  "type": "MINION",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1008
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_565 : SimTemplate//Flametongue Totem
    {
        // note buff and debuff is handled by playfield (faster)
        // Handled in updateBoards()
        /*
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.zonepos - 1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, 2, 0);
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos - 1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, 2, 0);
                    }
                }
            }

        }


        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.zonepos - 1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, -2, 0);
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos - 1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, -2, 0);
                    }
                }
            }
        }
        */


    }
}
