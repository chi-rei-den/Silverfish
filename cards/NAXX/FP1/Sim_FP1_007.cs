using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_007",
  "name": [
    "蛛魔之卵",
    "Nerubian Egg"
  ],
  "text": [
    "<b>亡语：</b>召唤一个4/4的蛛魔。",
    "<b>Deathrattle:</b> Summon a 4/4 Nerubian."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1786
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_007 : SimTemplate //* nerubianegg
	{
        //todesröcheln:/ ruft einen neruber (4/4) herbei.
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_007t);//nerubian
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(c, m.zonepos-1, m.own);
        }
	}
}