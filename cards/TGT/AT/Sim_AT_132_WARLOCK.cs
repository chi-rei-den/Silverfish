using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_WARLOCK",
  "name": [
    "灵魂分流",
    "Soul Tap"
  ],
  "text": [
    "<b>英雄技能</b>\n抽一张牌。",
    "<b>Hero Power</b>\nDraw a card."
  ],
  "cardClass": "WARLOCK",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2744
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_WARLOCK : SimTemplate //* Soul Tap
	{
		//Hero Power. Draw a card (without the Health penalty)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
        }
	}
}