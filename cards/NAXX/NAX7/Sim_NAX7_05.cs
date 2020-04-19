using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX7_05",
  "name": [
    "精神控制水晶",
    "Mind Control Crystal"
  ],
  "text": [
    "激活水晶来控制死亡学员！",
    "Activate the Crystal to control the Understudies!"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1960
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX7_05 : SimTemplate //* Mind Control Crystal
	{
		// Activate the Crystal to control the Understudies!

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            foreach (Minion m in ownplay ? p.enemyMinions : p.ownMinions)
            {
				if (m.name == CardIds.NonCollectible.Neutral.Understudy) p.minionGetControlled(m, ownplay, true);
			}
		}
	}
}