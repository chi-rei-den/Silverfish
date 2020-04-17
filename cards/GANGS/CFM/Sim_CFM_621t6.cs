using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t6",
  "name": [
    "金棘草",
    "Goldthorn"
  ],
  "text": [
    "使你的所有随从获得+2生命值。",
    "Give your minions +2 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41586
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t6 : SimCard //* Goldthorn
	{
		// Give your minions +2 Health.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.allMinionOfASideGetBuffed(ownplay, 0, 2);
		}
	}
}