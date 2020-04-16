using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA09_2H",
  "name": [
    "打开大门",
    "Open the Gates"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤三个2/2的雏龙。获得另一个英雄技能。",
    "<b>Hero Power</b>\nSummon three 2/2 Whelps. Get a new Hero Power."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2530
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA09_2H : SimTemplate //* Open the Gates
	{
		// Hero Power: Summon three 2/2 Whelps. Get a new Hero Power.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRMA09_2Ht);//2/2Whelp
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
            p.callKid(kid, place, ownplay);
        }
	}
}