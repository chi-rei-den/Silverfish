using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_042a",
  "name": [
    "雄狮形态",
    "Lion Form"
  ],
  "text": [
    "<b>冲锋</b>",
    "<b>Charge</b>"
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": null,
  "dbfId": 2861
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_042a : SimTemplate //* Lion Form
	{
		//Transform into a Charge
		
        Chireiden.Silverfish.SimCard Charge = CardIds.NonCollectible.Druid.DruidoftheSaber_DruidOfTheSaberToken1;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, Charge);
        }
	}
}