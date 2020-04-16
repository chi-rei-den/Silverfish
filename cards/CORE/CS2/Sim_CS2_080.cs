using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_080",
  "name": [
    "刺客之刃",
    "Assassin's Blade"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 421
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_080 : SimTemplate //assassinsblade
	{

//
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_080);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }

	}
}