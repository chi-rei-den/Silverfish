using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_807",
  "name": [
    "葛拉卡爬行蟹",
    "Golakka Crawler"
  ],
  "text": [
    "<b>战吼：</b>消灭一个海盗，并获得+1/+1。",
    "<b>Battlecry:</b> Destroy a Pirate and gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41316
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_807 : SimCard //* Golakka Crawler
	{
		//Battlecry: Destroy a Pirate and gain +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 1, 1);
            }
        } 
    }
}
