using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_210",
  "name": [
    "暗影升腾者",
    "Shadow Ascendant"
  ],
  "text": [
    "在你的回合结束时，随机使另一个友方随从获得+1/+1。",
    "[x]At the end of your turn,\ngive another random\nfriendly minion +1/+1."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42574
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_210: SimTemplate //* Shadow Ascendant
    {
        // At the end of your turn, give another random friendly minion +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                List<Minion> tmp = new List<Minion>(turnEndOfOwner ? p.ownMinions : p.enemyMinions);
                tmp.Sort((a, b) => a.Hp.CompareTo(b.Hp)); //buff the weakest
                foreach (Minion m in tmp)
                {
                    if (triggerEffectMinion.entitiyID == m.entitiyID) continue;
                    p.minionGetBuffed(m, 1, 1);
                    break;
                }
            }
        }
    }
}