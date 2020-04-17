using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_103",
  "name": [
    "微型战斗机甲",
    "Micro Machine"
  ],
  "text": [
    "在每个回合开始时，获得+1攻击力。",
    "At the start of each turn, gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2071
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_103 : SimCard //Micro Machine
    {

        //   At the start of each turn, gain +1 Attack.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }


    }

}