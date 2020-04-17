using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_144",
  "name": [
    "暗影步",
    "Shadowstep"
  ],
  "text": [
    "将一个友方随从移回你的手牌，它的法力值消耗减少\n（2）点。",
    "Return a friendly minion to your hand. It costs (2) less."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 0,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 365
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_144 : SimCard //* shadowstep
	{
        //Return a friendly minion to your hand. It costs (2) less.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, ownplay, -2);
		}

	}
}