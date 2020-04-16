using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_004",
  "name": [
    "真言术：盾",
    "Power Word: Shield"
  ],
  "text": [
    "使一个随从获得+2生命值。",
    "Give a minion +2 Health."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 613
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_004 : SimTemplate //powerwordshield
	{

//    verleiht einem diener +2 leben.\nzieht eine karte.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 0, 2);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}

	}
}