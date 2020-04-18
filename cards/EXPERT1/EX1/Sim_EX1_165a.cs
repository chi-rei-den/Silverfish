using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_165a",
  "name": [
    "猎豹形态",
    "Cat Form"
  ],
  "text": [
    "<b>冲锋</b>",
    "<b>Charge</b>"
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 63
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_165a : SimTemplate //* Cat Form
	{
        //Charge

        Chireiden.Silverfish.SimCard cat = CardIds.NonCollectible.Druid.DruidoftheClaw_DruidOfTheClawTokenClassic1;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, cat);
        }
	}
}