using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_214",
  "name": [
    "黑曜石雕像",
    "Obsidian Statue"
  ],
  "text": [
    "<b>嘲讽</b>，<b>吸血</b>\n<b>亡语：</b>随机消灭一个敌方随从。",
    "[x]<b>Taunt, Lifesteal</b>\n<b>Deathrattle:</b> Destroy a\n random enemy minion."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 9,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42598
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_214: SimTemplate //* Obsidian Statue
    {
        // Taunt. Lifesteal. Deathrattle: Destroy a random enemy minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = p.searchRandomMinion(m.own ? p.enemyMinions : p.ownMinions, SearchMode.LowHealth);
            if (target != null) p.minionGetDestroyed(target);
        }
    }
}