using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_050",
  "name": [
    "寒光智者",
    "Coldlight Oracle"
  ],
  "text": [
    "<b>战吼：</b>每个玩家抽两张牌。",
    "<b>Battlecry:</b> Each player draws 2 cards."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1016
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_050 : SimTemplate //coldlightoracle
	{

//    kampfschrei:/ jeder spieler zieht 2 karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, true);
            p.drawACard(CardDB.cardIDEnum.None, true);
            p.drawACard(CardDB.cardIDEnum.None, false);
            p.drawACard(CardDB.cardIDEnum.None, false);

		}


	}
}