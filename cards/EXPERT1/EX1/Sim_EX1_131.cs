using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_131",
  "name": [
    "迪菲亚头目",
    "Defias Ringleader"
  ],
  "text": [
    "<b>连击：</b>召唤一个2/1的迪菲亚强盗。",
    "<b>Combo:</b> Summon a 2/1 Defias Bandit."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 201
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_131 : SimTemplate //defiasringleader
	{
        Chireiden.Silverfish.SimCard card = CardIds.NonCollectible.Rogue.DefiasRingleader_DefiasBanditToken;
//    combo:/ ruft einen banditen der defias (2/1) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1)
            {
                p.callKid(card, own.zonepos, own.own);
            }
		}


	}
}