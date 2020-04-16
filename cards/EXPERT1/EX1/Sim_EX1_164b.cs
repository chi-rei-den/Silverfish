using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_164b",
  "name": [
    "摄取养分",
    "Enrich"
  ],
  "text": [
    "抽三张牌。",
    "Draw 3 cards."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 325
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_164b : SimTemplate //nourish
	{

//    zieht 3 karten.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}

	}
}