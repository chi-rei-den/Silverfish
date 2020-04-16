using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_014",
  "name": [
    "伪装大师",
    "Master of Disguise"
  ],
  "text": [
    "<b>战吼：</b>直到你的下个回合，使一个友方随从获得<b>潜行</b>。",
    "<b>Battlecry:</b> Give a friendly minion <b>Stealth</b> until your next turn."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 887
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_014 : SimTemplate //* Master of Disguise
	{
        // Battlecry: Give a friendly minion Stealth until your next turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                target.stealth = true;
                target.conceal = true;
            }
		}
	}
}