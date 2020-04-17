using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t7",
  "name": [
    "反魔法护罩",
    "Anti-Magic Shell"
  ],
  "text": [
    "使你的所有随从获得+2/+2，且“无法成为法术或英雄技能的\n目标。”",
    "Give your minions +2/+2 and \"Can't be targeted by spells or Hero Powers.\""
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 45387
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t7 : SimCard //* Anti-Magic Shell
    {
        // Give your minions +2/+2 and "Can't be targeted by spells or Hero Powers."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 2, 2);

            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp) m.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}