using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_112",
  "name": [
    "奥金斧",
    "Arcanite Reaper"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 304
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_112 : SimTemplate //arcanitereaper
	{

        Chireiden.Silverfish.SimCard card = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_112);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card,ownplay);
        }

	}
}