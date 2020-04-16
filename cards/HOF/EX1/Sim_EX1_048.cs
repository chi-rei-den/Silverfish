using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_048",
  "name": [
    "破法者",
    "Spellbreaker"
  ],
  "text": [
    "<b>战吼：</b>\n<b>沉默</b>一个随从。",
    "<b>Battlecry:</b> <b>Silence</b> a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 754
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_048 : SimTemplate //spellbreaker
	{

//    kampfschrei:/ bringt einen diener zum schweigen/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetSilenced(target);
		}


	}
}