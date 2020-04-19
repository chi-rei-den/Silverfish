using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX8_02",
  "name": [
    "收割",
    "Harvest"
  ],
  "text": [
    "<b>英雄技能</b>\n抽一张牌。",
    "<b>Hero Power</b>\nDraw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1872
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX8_02 : SimTemplate //* Harvest
	{

//    Hero PowerDraw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
        }
	}
}