using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_031",
  "name": [
    "窃贼",
    "Cutpurse"
  ],
  "text": [
    "每当该随从攻击一方英雄，会将幸运币置入你的手牌。",
    "Whenever this minion attacks a hero, add the Coin to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2766
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_031 : SimCard //* Cutpurse
	{
		//When this minion attacks the enemy hero, put a Coin into your hand.
		//done in triggerAMinionIsGoingToAttack

	}
}