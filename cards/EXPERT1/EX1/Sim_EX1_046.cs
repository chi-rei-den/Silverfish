using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_046",
  "name": [
    "黑铁矮人",
    "Dark Iron Dwarf"
  ],
  "text": [
    "<b>战吼：</b>\n本回合中，使一个随从获得+2攻击力。",
    "<b>Battlecry:</b> Give a minion +2 Attack this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 348
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_046 : SimCard//Dark Iron Dwarf
    {
        // +2 tempattack
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetTempBuff(target, 2, 0);
        }
    }
}
