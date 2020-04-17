using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t3",
  "name": [
    "石鳞鱼油",
    "Stonescale Oil"
  ],
  "text": [
    "获得4点护甲值。",
    "Gain 4 Armor."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41589
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t3 : SimCard //* Stonescale Oil
	{
		// Gain 4 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 4);
        }
    }
}