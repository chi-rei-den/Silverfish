using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_013",
  "name": [
    "真言术：耀",
    "Power Word: Glory"
  ],
  "text": [
    "选择一个随从。每当其进行攻击，为你的英雄恢复\n4点生命值。",
    "Choose a minion. Whenever it attacks, restore 4 Health to\nyour hero."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2568
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_013 : SimCard //* Power Word: Glory
	{
		//Choose a minion. Whenever it at tacks, restore 4 health to your hero.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                target.ownPowerWordGlory++;
            }
            else
            {
                target.enemyPowerWordGlory++;
            }
		}
	}
}