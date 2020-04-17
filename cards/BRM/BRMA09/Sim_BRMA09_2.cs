using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA09_2",
  "name": [
    "打开大门",
    "Open the Gates"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤三个1/1的雏龙。获得另一个英雄技能。",
    "<b>Hero Power</b>\nSummon three 1/1 Whelps. Get a new Hero Power."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2345
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA09_2 : SimCard //* Open the Gates
	{
		// Hero Power: Summon three 1/1 Whelps. Get a new Hero Power.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRMA09_2t);//1/1Whelp
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
            p.callKid(kid, place, ownplay);
            p.callKid(kid, place, ownplay);
        }
	}
}