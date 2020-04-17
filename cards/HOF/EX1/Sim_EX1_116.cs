using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_116",
  "name": [
    "火车王里诺艾",
    "Leeroy Jenkins"
  ],
  "text": [
    "<b>冲锋，战吼：</b>\n为你的对手召唤两条1/1的雏龙。",
    "<b>Charge</b>. <b>Battlecry:</b> Summon two 1/1 Whelps for your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 559
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_116 : SimCard //leeroyjenkins
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t);//whelp
//    ansturm/. kampfschrei:/ ruft zwei welplinge (1/1) für euren gegner herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{

            int pos = (own.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !own.own);
            p.callKid(kid, pos, !own.own);
		}
	}
}