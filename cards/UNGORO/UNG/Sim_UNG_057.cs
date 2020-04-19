using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_057",
  "name": [
    "刀瓣齐射",
    "Razorpetal Volley"
  ],
  "text": [
    "将两张可造成1点伤害的“刀瓣”置入你的手牌。",
    "Add two Razorpetals to your hand that deal 1 damage."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41207
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_057 : SimTemplate //* Razorpetal Volley
	{
		//Add two Razorpetals to your hand that deal 1 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.NonCollectible.Rogue.RazorpetalVolley_RazorpetalToken,ownplay, true);
            p.drawACard(CardIds.NonCollectible.Rogue.RazorpetalVolley_RazorpetalToken, ownplay, true);
        }
    }
}