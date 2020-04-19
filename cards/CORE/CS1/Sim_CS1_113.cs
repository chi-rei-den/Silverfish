using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS1_113",
  "name": [
    "精神控制",
    "Mind Control"
  ],
  "text": [
    "获得一个敌方随从的控制权。",
    "Take control of an enemy minion."
  ],
  "CardClass": "PRIEST",
  "type": "SPELL",
  "cost": 10,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 8
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS1_113 : SimTemplate //mindcontrol
	{

//    übernehmt die kontrolle über einen feindlichen diener.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetControlled(target, ownplay, false);
		}

	}
}