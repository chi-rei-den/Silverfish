using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_131",
  "name": [
    "黑暗邪使艾蒂丝",
    "Eydis Darkbane"
  ],
  "text": [
    "每当<b>你</b>以该随从为目标施放一个法术时，便随机对一个敌人造成3点伤害。",
    "Whenever <b>you</b> target this minion with a spell, deal 3 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2519
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_131 : SimCard //* Eydis Darkbane
	{
		//Whenever you target this minion with a spell, deal 3 damage to a random enemy.
		// handled in public void playACard
	}
}