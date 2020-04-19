using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t31",
  "name": [
    "暗影之油",
    "Shadow Oil"
  ],
  "text": [
    "随机将三张恶魔牌置入你的手牌。",
    "Add 3 random Demons to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41627
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t31 : SimTemplate //* Shadow Oil
	{
		// Add 3 random Demons to your hand.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
		    p.drawACard(CardIds.Collectible.Warlock.MalchezaarsImp, ownplay, true);
		    p.drawACard(CardIds.NonCollectible.Neutral.Kazakus_KabalDemon1, ownplay, true);
		    p.drawACard(CardIds.NonCollectible.Neutral.Kazakus_KabalDemon3, ownplay, true);
		}
	}
}