using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_076",
  "name": [
    "刺杀",
    "Assassinate"
  ],
  "text": [
    "消灭一个敌方随从。",
    "Destroy an enemy minion."
  ],
  "CardClass": "ROGUE",
  "type": "SPELL",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 345
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_076 : SimTemplate//Assassinate
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }

    }
}
