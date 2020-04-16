using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_332",
  "name": [
    "沉默",
    "Silence"
  ],
  "text": [
    "<b>沉默</b>一个随从。",
    "<b>Silence</b> a minion."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 0,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1189
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_332 : SimTemplate //silence
	{

//    bringt einen diener zum schweigen/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
		}

	}
}