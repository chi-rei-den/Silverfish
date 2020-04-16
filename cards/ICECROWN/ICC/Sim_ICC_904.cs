using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_904",
  "name": [
    "邪骨骷髅",
    "Wicked Skeleton"
  ],
  "text": [
    "<b>战吼：</b>在本回合中每有一个随从死亡，便获得+1/+1。",
    "<b>Battlecry:</b> Gain +1/+1 for each minion that died this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45328
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_904: SimTemplate //* Wicked Skeleton
    {
        // Battlecry: Gain +1/+1 for each minion that died this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int buff = (own.own) ? p.ownMinionsDiedTurn : p.enemyMinionsDiedTurn;
            p.minionGetBuffed(own, buff, buff);
        }
    }
}