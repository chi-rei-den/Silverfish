using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_914",
  "name": [
    "迅猛龙宝宝",
    "Raptor Hatchling"
  ],
  "text": [
    "<b>亡语：</b>将一张4/3的“迅猛龙头领”洗入你的\n牌库。",
    "<b>Deathrattle:</b> Shuffle a 4/3 Raptor into your deck."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41357
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_914 : SimCard //* Raptor Hatchling
	{
		//Deathrattle: Shuffle a 4/3 Raptor into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}