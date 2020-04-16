using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_070",
  "name": [
    "执刃教徒",
    "Bladed Cultist"
  ],
  "text": [
    "<b>连击：</b>获得+1/+1。",
    "<b>Combo:</b> Gain +1/+1."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38391
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_070 : SimTemplate //* Bladed Cultist
	{
		//Combo: Gain +1/+1.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{			
            if (p.cardsPlayedThisTurn > 0)
            {
                p.minionGetBuffed(own, 1, 1);
            }
		}
	}
}