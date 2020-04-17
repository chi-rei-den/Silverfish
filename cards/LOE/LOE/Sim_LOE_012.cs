using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_012",
  "name": [
    "盗墓匪贼",
    "Tomb Pillager"
  ],
  "text": [
    "<b>亡语：</b>将一个幸运币置入你的手牌。",
    "<b>Deathrattle:</b> Add a Coin to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2884
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_012 : SimCard //* Tomb Pillager
	{
		//Deathrattle: Put a Coin into your hand.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.thecoin, m.own);
        }
    }
}