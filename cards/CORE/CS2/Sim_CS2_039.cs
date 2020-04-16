using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_039",
  "name": [
    "风怒",
    "Windfury"
  ],
  "text": [
    "使一个随从获得<b>风怒</b>。",
    "Give a minion <b>Windfury</b>."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 51
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_039 : SimTemplate //windfury
	{

//    verleiht einem diener windzorn/.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetWindfurry(target);
		}

	}
}