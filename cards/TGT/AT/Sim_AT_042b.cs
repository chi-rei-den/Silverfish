using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_042b",
  "name": [
    "黑豹形态",
    "Panther Form"
  ],
  "text": [
    "<b>潜行</b>",
    "<b>Stealth</b>"
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": null,
  "dbfId": 2862
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_042b : SimCard //* Panther Form
	{
		//Transform into a +1/+1 and Stealth
		
        CardDB.Card Stealth = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t2);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, Stealth);
        }
	}
}