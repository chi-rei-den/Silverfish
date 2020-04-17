using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA01_2H",
  "name": [
    "干杯！",
    "Pile On!"
  ],
  "text": [
    "<b>英雄技能</b>\n从你的牌库中将两个随从置入战场；对手将一个随从置入战场。",
    "<b>Hero Power</b>\nPut two minions from your deck and one from your opponent's into the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2439
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA01_2H : SimCard //* Pile On!
	{
		// Hero Power: Put two minions from your deck and one from your opponent's into the battlefield.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_007t);//4/4Nerubian

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