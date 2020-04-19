using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_011",
  "name": [
    "野蛮咆哮",
    "Savage Roar"
  ],
  "text": [
    "在本回合中，使你的所有角色获得+2攻击力。",
    "Give your characters +2 Attack this turn."
  ],
  "CardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 742
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_011 : SimTemplate //savageroar
    {

        //    verleiht euren charakteren +2 angriff in diesem zug.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion t in temp)
            {
                p.minionGetTempBuff(t, 2, 0);
            }
            p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 2, 0);
        }

    }
}