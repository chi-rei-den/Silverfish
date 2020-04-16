using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_013",
  "name": [
    "净化",
    "Purify"
  ],
  "text": [
    "<b>沉默</b>一个友方随从，抽一张牌。",
    "<b>Silence</b> a friendly minion. Draw a card."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39468
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_013 : SimTemplate //* Purify
	{
		//Silence a friendly minion. Draw a card.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}
	}
}