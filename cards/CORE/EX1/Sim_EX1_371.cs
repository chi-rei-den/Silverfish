using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_371",
  "name": [
    "保护之手",
    "Hand of Protection"
  ],
  "text": [
    "使一个随从获得<b>圣盾</b>。",
    "Give a minion <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 727
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_371 : SimCard //handofprotection
	{

//    verleiht einem diener gottesschild/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.divineshild = true;
		}

	}
}