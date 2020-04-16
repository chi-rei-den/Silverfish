using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_025",
  "name": [
    "转生",
    "Reincarnate"
  ],
  "text": [
    "消灭一个随从，然后将其复活，并具有所有生命值。",
    "Destroy a minion, then return it to life with full Health."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1809
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_025 : SimTemplate //reincarnate
	{

//    vernichtet einen diener und bringt ihn dann mit vollem leben wieder auf das schlachtfeld zurück.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            bool own = target.own;
            int place = target.zonepos;
            CardDB.Card d = target.handcard.card;
            p.minionGetDestroyed(target);
            p.callKid(d, place, own);
		}

	}
}