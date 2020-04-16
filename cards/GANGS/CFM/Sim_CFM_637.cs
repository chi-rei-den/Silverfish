using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_637",
  "name": [
    "海盗帕奇斯",
    "Patches the Pirate"
  ],
  "text": [
    "在你使用一张海盗牌后，从你的牌库中将该随从置入战场。",
    "[x]After you play a Pirate,\nsummon this minion\nfrom your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40465
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_637 : SimTemplate //* Patches the Pirate
	{
		// Charge. After you play a Pirate, summon this minion from your deck.
	}
}