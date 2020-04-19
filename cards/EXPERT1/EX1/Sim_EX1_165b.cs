using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_165b",
  "name": [
    "熊形态",
    "Bear Form"
  ],
  "text": [
    "<b>嘲讽</b>",
    "<b>Taunt</b>"
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 99
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_165b : SimTemplate //bearform
	{

//    +2 leben und spott/.
        SimCard bear = CardIds.NonCollectible.Druid.DruidoftheClaw_DruidOfTheClawTokenClassic2;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, bear);
        }
	}
}