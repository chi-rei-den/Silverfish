using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_010b",
  "name": [
    "火鹰形态",
    "Fire Hawk Form"
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
  "dbfId": 2294
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_010b : SimCard //* Fire Hawk Form
	{
		// Transform into a 2/5 minion.

        CardDB.Card hawk = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t2);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, hawk);
        }
	}
}