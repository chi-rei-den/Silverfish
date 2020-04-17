using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_088",
  "name": [
    "始祖龟预言者",
    "Tortollan Primalist"
  ],
  "text": [
    "<b>战吼：</b>\n<b>发现</b>一张法术牌，并向随机目标施放。",
    "<b>Battlecry:</b> <b>Discover</b> a spell and cast it with random targets."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41264
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_088 : SimCard //* Tortollan Primalist
	{
		//Battlecry: Discover a spell and cast it with random targets.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			p.evaluatePenality -= 10;
        }
    }
}