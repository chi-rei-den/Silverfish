using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_tk33",
  "name": [
    "地狱火！",
    "INFERNO!"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个6/6的\n地狱火。",
    "<b>Hero Power</b>\nSummon a 6/6 Infernal."
  ],
  "cardClass": "WARLOCK",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1178
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_tk33 : SimTemplate //* inferno
	{
        //Hero PowerSummon a 6/6 Infernal.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk34);//infernal

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
		}
	}
}