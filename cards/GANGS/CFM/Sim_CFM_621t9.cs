using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t9",
  "name": [
    "暗影之油",
    "Shadow Oil"
  ],
  "text": [
    "随机将一张恶魔牌置入你的手牌。",
    "Add a random Demon to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41583
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t9 : SimTemplate //* Shadow Oil
	{
		// Add a random Demon to your hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
		    p.drawACard(CardIds.NonCollectible.Neutral.Kazakus_KabalDemon3, ownplay, true);
		}
	}
}