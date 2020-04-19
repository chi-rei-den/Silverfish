using HearthDb.Enums;
using HearthDb;
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
  "CardClass": "NEUTRAL",
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
	class Sim_BOT_312t : SimTemplate //* 微型机器人 Microbot
	{
		//
		//
		// Chireiden.Silverfish.SimCard kid = CardDB. Instance.getCardDataFromID(CardIds.NonCollectible.Neutral.ReplicatingMenace_MicrobotToken);
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
{
if (own.own) p.Magnetic(own);
}


	}
}