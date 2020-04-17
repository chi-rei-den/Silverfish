using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_096",
  "name": [
    "玛克扎尔王子",
    "Prince Malchezaar"
  ],
  "text": [
    "<b>对战开始时：</b>额外将五张<b>传说</b>随从牌置入你的牌库。",
    "[x]<b>Start of Game:</b>\nAdd 5 extra <b>Legendary</b>\nminions to your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39840
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_096 : SimCard //* Prince Malchezaar
	{
		//At the start of the game, shuffle 5 extra Legendary minions into your deck.
	}
}