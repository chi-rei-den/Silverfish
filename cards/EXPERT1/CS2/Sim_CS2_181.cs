using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_181",
  "name": [
    "负伤剑圣",
    "Injured Blademaster"
  ],
  "text": [
    "<b>战吼：</b>对自身造成4点伤害。",
    "<b>Battlecry:</b> Deal 4 damage to HIMSELF."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1109
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_181 : SimTemplate//Injured Blademaster
    {

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            p.minionGetDamageOrHeal(own, 4);
        }

    }
}
