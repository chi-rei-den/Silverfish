using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_536",
  "name": [
    "鹰角弓",
    "Eaglehorn Bow"
  ],
  "text": [
    "每当有一张\n你的<b>奥秘</b>牌被揭示时，便获得+1耐久度。",
    "[x]Whenever a friendly\n<b>Secret</b> is revealed,\ngain +1 Durability."
  ],
  "cardClass": "HUNTER",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1662
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_536 : SimTemplate //eaglehornbow
	{

//    erhält jedes mal +1 haltbarkeit, wenn ein eigenes geheimnis/ aufgedeckt wird.

        Chireiden.Silverfish.SimCard weapon = CardIds.Collectible.Hunter.EaglehornBow;

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}

	}
}