using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA14_10H",
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
  "set": "BRM",
  "collectible": null,
  "dbfId": 2482
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA14_10H : SimCard //* Activate!
	{
		// Hero Power: Activate a random Tron.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRMA14_5H);//4/4toxitron
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}