using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA01_2H_2_TB",
  "name": [
    "干杯！",
    "Pile On!!!"
  ],
  "text": [
    "<b>英雄技能</b>\n从双方的牌库中\n各将一个随从\n置入战场。",
    "<b>Hero Power</b>\nPut a minion from each deck into the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 30463
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA01_2H_2_TB : SimTemplate //* Pile On!
	{
		// Hero Power: Put two minions from your deck and one from your opponent's into the battlefield.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.NerubianEgg_NerubianToken;//4/4Nerubian

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (p.ownDeckSize > 0)
            {
                p.callKid(kid, p.ownMinions.Count, true, false);
                p.ownDeckSize--;
            }
			
            if (p.enemyDeckSize > 0)
            {
                p.callKid(kid, p.enemyMinions.Count, false, false);
                p.enemyDeckSize--;
            }
			
			if (ownplay)
			{
				if (p.ownDeckSize > 0)
				{
                    p.callKid(kid, p.ownMinions.Count, true, false);
					p.ownDeckSize--;
				}
			}
			else
			{
				if (p.enemyDeckSize > 0)
				{
                    p.callKid(kid, p.enemyMinions.Count, false, false);
					p.enemyDeckSize--;
				}
			}
		}
	}
}