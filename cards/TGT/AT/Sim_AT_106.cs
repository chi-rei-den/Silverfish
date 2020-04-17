using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_106",
  "name": [
    "圣光勇士",
    "Light's Champion"
  ],
  "text": [
    "<b>战吼：</b>\n<b>沉默</b>一个恶魔。",
    "<b>Battlecry:</b> <b>Silence</b> a Demon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2259
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_106 : SimCard //* Light's Champion
	{
		//Battlecry: Silence a Demon.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetSilenced(target);
		}
	}
}