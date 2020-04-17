using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_038",
  "name": [
    "格鲁尔",
    "Gruul"
  ],
  "text": [
    "在每个回合结束时，获得+1/+1。",
    "At the end of each turn, gain +1/+1 ."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 526
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_038 : SimCard//Gruul
    {
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 1);
        }
        

    }
}
