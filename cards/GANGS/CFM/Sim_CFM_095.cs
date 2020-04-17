using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_095",
  "name": [
    "鼬鼠挖掘工",
    "Weasel Tunneler"
  ],
  "text": [
    "<b>亡语：</b>将该随从洗入你对手的牌库。",
    "<b>Deathrattle:</b> Shuffle this minion into your opponent's deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40549
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_095 : SimCard //* Weasel Tunneler
	{
		// Deathrattle: Shuffle this minion into your opponent's deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.enemyDeckSize++;
            else p.ownDeckSize++;
        }
    }
}