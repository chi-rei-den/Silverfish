using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_846",
  "name": [
    "活体风暴",
    "Shimmering Tempest"
  ],
  "text": [
    "<b>亡语：</b>\n随机将一张法师法术牌置入你的手牌。",
    "<b>Deathrattle:</b> Add a random Mage spell to your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41927
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_846 : SimCard //* Shimmering Tempest
	{
		//Deathrattle: Add a random Mage spell to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.None, m.own, true);
        }
	}
}