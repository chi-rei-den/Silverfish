using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_104",
  "name": [
    "埋葬",
    "Entomb"
  ],
  "text": [
    "选择一个敌方随从。将该随从洗入你的牌库。",
    "Choose an enemy minion.\nShuffle it into your deck."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 6,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 3015
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_104 : SimCard //* Entomb
	{
		//Choose an enemy minion. Shuffle it into your deck.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToDeck(target, ownplay);
		}
	}
}