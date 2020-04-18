using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_845",
  "name": [
    "火岩元素",
    "Igneous Elemental"
  ],
  "text": [
    "<b>亡语：</b>将两张1/2的元素牌置入你的手牌。",
    "<b>Deathrattle:</b> Add two 1/2 Elementals to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41926
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_845 : SimTemplate //* Igneous Elemental
	{
		//Deathrattle: Add two 1/2 Elementals to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.FireFly_FlameElementalToken, m.own, true);
            p.drawACard(CardIds.NonCollectible.Neutral.FireFly_FlameElementalToken, m.own, true);
        }
	}
}