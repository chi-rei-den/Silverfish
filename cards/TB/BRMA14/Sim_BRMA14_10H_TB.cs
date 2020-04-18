using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA14_10H_TB",
  "name": [
    "激活！",
    "Activate!"
  ],
  "text": [
    "<b>英雄技能</b>\n随机激活一个金刚。",
    "<b>Hero Power</b>\nActivate a random Tron."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 36734
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA14_10H_TB : SimTemplate //* Activate!
	{
		// Hero Power: Activate a random Tron.

		Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.BRMA14_5H);//4/4toxitron
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}