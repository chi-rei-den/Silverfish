using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_912",
  "name": [
    "宝石鹦鹉",
    "Jeweled Macaw"
  ],
  "text": [
    "<b>战吼：</b>随机将一张野兽牌置入你的手牌。",
    "<b>Battlecry:</b> Add a random Beast to your hand."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41353
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_912 : SimTemplate //* Jeweled Macaw
	{
		//Battlecry: Add a random Beast to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.rivercrocolisk, own.own, true);
        }
}
}