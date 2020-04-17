using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_630",
  "name": [
    "伪造的幸运币",
    "Counterfeit Coin"
  ],
  "text": [
    "在本回合中，获得一个法力\n水晶。",
    "Gain 1 Mana Crystal this turn only."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 0,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40437
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_630 : SimCard //* Counterfeit Coin
	{
		// Gain 1 Mana Crystal this turn only.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.mana = Math.Min(p.mana + 1, 10);
        }
    }
}