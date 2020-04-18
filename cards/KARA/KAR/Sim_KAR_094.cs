using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_094",
  "name": [
    "致命餐叉",
    "Deadly Fork"
  ],
  "text": [
    "<b>亡语：</b>将一张3/2的武器牌置入你的手牌。",
    "<b>Deathrattle:</b> Add a 3/2 weapon to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39822
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_094 : SimTemplate //* Deadly Fork
	{
		//Deathrattle: Add a 3/2 weapon to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.sharpfork, m.own, true);
        }
    }
}