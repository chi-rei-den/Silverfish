using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_010a",
  "name": [
    "火焰猎豹形态",
    "Firecat Form"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": null,
  "dbfId": 2293
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_010a : SimCard //* Firecat Form
	{
		// Transform into a 5/2 minion.
		
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, cat);
        }
	}
}