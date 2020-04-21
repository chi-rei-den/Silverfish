using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_469",
  "name": [
    "强制牺牲",
    "Unwilling Sacrifice"
  ],
  "text": [
    "选择一个友方随从，消灭该随从和一个随机敌方随从。",
    "Choose a friendly minion. Destroy it and a random enemy minion."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42391
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_469: SimTemplate //* Unwilling Sacrifice
    {
        // Choose a friendly minion. Destroy it and a random enemy minion

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            Minion found = null;
            if (ownplay) found = p.searchRandomMinion(p.enemyMinions, SearchMode.LowHealth);
            else found = p.searchRandomMinion(p.ownMinions, SearchMode.searchHighHPLowAttack);
            if (found != null) p.minionGetDestroyed(found);
        }
    }
}