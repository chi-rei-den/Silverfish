using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_011",
  "name": [
    "结网蛛",
    "Webspinner"
  ],
  "text": [
    "<b>亡语：</b>随机将一张野兽牌置入你的手牌。",
    "<b>Deathrattle:</b> Add a random Beast card to your hand."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1860
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_011 : SimTemplate //* webspinner
	{

//    todesröcheln:/ fügt eurer hand ein zufälliges wildtier hinzu.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.rivercrocolisk, m.own, true);
        }
	}
}