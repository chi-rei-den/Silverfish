using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX9_06",
  "name": [
    "邪恶之影",
    "Unholy Shadow"
  ],
  "text": [
    "<b>英雄技能</b>\n抽两张牌。",
    "<b>Hero Power</b>\nDraw 2 cards."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 5,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1883
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX9_06 : SimTemplate //* Unholy Shadow
	{
		// Hero Power: Draw 2 cards.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}
	}
}