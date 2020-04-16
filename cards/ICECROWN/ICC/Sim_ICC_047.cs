using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_047",
  "name": [
    "命运织网蛛",
    "Fatespinner"
  ],
  "text": [
    "<b>秘密亡语：</b>\n<b>抉择：</b>对所有随从造成3点伤害；或者使所有随从获得+2/+2。",
    "<b>Choose a Deathrattle (Secretly) -</b> Deal 3 damage to all minions; or Give them +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42615
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_047 : SimTemplate //* Fatespinner in hand
    {
        // Choose a Deathrattle (Secretly) - Deal 3 damage to all minions; or Give them +2/+2.
        
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int pen = 0;
            switch (choice)
            {
                case 1:
                    if (p.ownMinions.Count + 2 > p.enemyMinions.Count) pen = -5;
                    else pen = 5;
                    break;
                case 2:
                    if (p.enemyMinions.Count >= p.ownMinions.Count) pen = -8;
                    break;
            }
            p.evaluatePenality += pen;
        }
    }
}