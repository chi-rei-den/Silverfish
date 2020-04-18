using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_118",
  "name": [
    "十字军统领",
    "Grand Crusader"
  ],
  "text": [
    "<b>战吼：</b>\n随机将一张圣骑士牌置入你的手牌。",
    "<b>Battlecry:</b> Add a random Paladin card to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2510
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_118 : SimTemplate //* Grand Crusader
	{
		//Battlecry: Add a random Paladin card to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			p.drawACard(Chireiden.Silverfish.SimCard.None, m.own, true);
        }
    }
}