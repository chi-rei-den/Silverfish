using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_383t",
  "name": [
    "灰烬使者",
    "Ashbringer"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 5,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1730
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_383t : SimCard //ashbringer
	{

//
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_383t);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(wcard, ownplay);
        }

	}
}