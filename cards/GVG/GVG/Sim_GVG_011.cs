using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_011",
  "name": [
    "缩小射线工程师",
    "Shrinkmeister"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，使一个随从获得-2攻击力。",
    "<b>Battlecry:</b> Give a minion -2 Attack this turn."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1936
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_011 : SimTemplate //Shrinkmeister
    {
        // Battlecry: Give a minion -2 Attack this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetTempBuff(target, -2, 0);
            }
        }
    }
}