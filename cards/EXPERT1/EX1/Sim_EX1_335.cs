using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_335",
  "name": [
    "光耀之子",
    "Lightspawn"
  ],
  "text": [
    "该随从的攻击力等同于其生命值。",
    "This minion's Attack is always equal to its Health."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 886
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_335 : SimTemplate //lightspawn
	{

//    der angriff dieses dieners entspricht immer seinem leben.
        //todo dont buff this!
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.Angr = own.Hp;
		}

	}
}