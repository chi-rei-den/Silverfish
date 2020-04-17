using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "BOT_312t",
  "name": [
    "微型机器人",
    "Microbot"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "BOOMSDAY",
  "collectible": null,
  "dbfId": 48842
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_312t : SimCard //* 微型机器人 Microbot
	{
		//
		//
		// CardDB.Card kid = CardDB. Instance.getCardDataFromID(CardDB.cardIDEnum.BOT_312t);
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}