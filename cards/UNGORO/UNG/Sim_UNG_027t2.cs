using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_027t2",
  "name": [
    "派烙斯",
    "Pyros"
  ],
  "text": [
    "<b>亡语：</b>将该随从移回你的手牌，并变为法力值消耗为（10）点的10/10随从牌。",
    "<b>Deathrattle:</b> Return this to your hand as a 10/10 that costs (10)."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41164
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_027t2 : SimTemplate //* Pyros
	{
		//Deathrattle: Return this to your hand as a 10/10 that costs (10).

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.NonCollectible.Mage.Pyros_PyrosToken2, m.own, true);
        }
	}
}