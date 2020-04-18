using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_078",
  "name": [
    "始祖龟劫掠者",
    "Tortollan Forager"
  ],
  "text": [
    "<b>战吼：</b>随机将一张攻击力大于或等于5的随从牌置入你的手牌。",
    "<b>Battlecry:</b> Add a random minion with 5 or more Attack to your hand."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41252
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_078 : SimTemplate //* Tortollan Forager
	{
		//Battlecry: Add a random minion with 5 or more Attack to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Neutral.BootyBayBodyguard, own.own, true);
        }
}
}