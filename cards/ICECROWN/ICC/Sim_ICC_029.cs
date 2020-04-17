using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_029",
  "name": [
    "深蓝刃鳞龙人",
    "Cobalt Scalebane"
  ],
  "text": [
    "在你的回合结束时，随机使另一个友方随从获得+3攻击力。",
    "At the end of your turn, give another random friendly minion +3 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42442
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_029: SimCard //* Cobalt Scalebane
    {
        // At the end of your turn, give another random friendly minion +3 Attack.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                List<Minion> tmp = turnEndOfOwner ? p.ownMinions : p.enemyMinions;
                int count = tmp.Count;
                if (count > 1)
                {
                    Minion mnn = null;
                    if (triggerEffectMinion.entitiyID != tmp[0].entitiyID) mnn = tmp[0];
                    else mnn = tmp[1];

                    for (int i = 1; i < count; i++)
                    {
                        if (triggerEffectMinion.entitiyID == tmp[i].entitiyID) continue;
                        if (tmp[i].Hp < mnn.Hp) mnn = tmp[i]; //take the weakest
                    }
                    if (mnn != null) p.minionGetBuffed(mnn, 3, 0);
                }
            }
        }
    }
}