using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_419",
  "name": [
    "熊鲨",
    "Bearshark"
  ],
  "text": [
    "无法成为法术或英雄技能的目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42711
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_419: SimTemplate //* Bearshark
    {
        // Can't be targeted by spells of Hero Powers.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}