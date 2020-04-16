using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_044",
  "name": [
    "任务达人",
    "Questing Adventurer"
  ],
  "text": [
    "每当你使用一张牌时，便获得+1/+1。",
    "Whenever you play a card, gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 791
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_044 : SimTemplate //questingadventurer
	{

//    erhält jedes mal +1/+1, wenn ihr eine karte ausspielt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }
	}
}