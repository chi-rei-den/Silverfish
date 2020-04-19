using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_096",
  "name": [
    "战利品贮藏者",
    "Loot Hoarder"
  ],
  "text": [
    "<b>亡语：</b>抽一张牌。",
    "<b>Deathrattle:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 251
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_096 : SimTemplate //* loothoarder
	{

//    todesröcheln:/ zieht eine karte.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(SimCard.None, m.own);
        }

	}
}