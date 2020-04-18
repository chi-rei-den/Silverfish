using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_058",
  "name": [
    "刀瓣鞭笞者",
    "Razorpetal Lasher"
  ],
  "text": [
    "<b>战吼：</b>将一张可造成1点伤害的“刀瓣”置入你的手牌。",
    "[x]<b>Battlecry:</b> Add a\nRazorpetal to your hand\nthat deals 1 damage."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41208
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_058 : SimTemplate //* Razorpetal Lasher
	{
		//Battlecry: Add a Razorpetal to your hand that deals 1 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.UNG_057t1, own.own, true);
        }
	}
}