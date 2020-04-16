using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t17",
  "name": [
    "石鳞鱼油",
    "Stonescale Oil"
  ],
  "text": [
    "获得7点护甲值。",
    "Gain 7 Armor."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41606
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t17 : SimTemplate //* Stonescale Oil
	{
		// Gain 7 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 7);
        }
    }
}