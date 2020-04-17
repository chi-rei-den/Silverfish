using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_147",
  "name": [
    "侏儒发明家",
    "Gnomish Inventor"
  ],
  "text": [
    "<b>战吼：</b>抽一张牌。",
    "<b>Battlecry:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 308
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_147 : SimCard //gnomishinventor
	{

//    kampfschrei:/ zieht eine karte.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own);
		}


	}
}