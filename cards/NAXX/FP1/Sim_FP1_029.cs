using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_029",
  "name": [
    "舞动之剑",
    "Dancing Swords"
  ],
  "text": [
    "<b>亡语：</b>你的对手抽一张牌。",
    "<b>Deathrattle:</b> Your opponent draws a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1913
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_029 : SimCard //dancingswords
	{

//    todesröcheln:/ euer gegner zieht eine karte.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.None, !m.own);
        }

	}
}