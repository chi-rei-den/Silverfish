using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_613",
  "name": [
    "艾德温·范克里夫",
    "Edwin VanCleef"
  ],
  "text": [
    "<b>连击：</b>在本回合中，你每使用一张其他牌，便获得+2/+2。",
    "<b>Combo:</b> Gain +2/+2 for each other card you've played this turn."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 306
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_613 : SimCard//edwin van cleefe
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

            if(own.own) p.minionGetBuffed(own, p.cardsPlayedThisTurn * 2, p.cardsPlayedThisTurn * 2);
            else p.minionGetBuffed(own, p.enemyAnzCards * 2, p.enemyAnzCards * 2);
        }

    }
}
