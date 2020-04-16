using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX1h_04",
  "name": [
    "飞掠召唤",
    "Skitter"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个4/4的\n蛛魔。",
    "<b>Hero Power</b>\nSummon a 4/4 Nerubian."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2103
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX1h_04 : SimTemplate //* Skitter
	{
		// Hero Power: Summon a 4/4 Nerubian.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX1h_03);//4/4Nerubian
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
	}
}