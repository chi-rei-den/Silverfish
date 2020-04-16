using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_169",
  "name": [
    "激活",
    "Innervate"
  ],
  "text": [
    "在本回合中，获得一个\n法力水晶。",
    "Gain 1 Mana Crystal this turn only."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 0,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 254
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_169 : SimTemplate //* Innervate
	{
        //Gain 1 Mana Crystal this turn only.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.mana = Math.Min(p.mana + 1, 10);
		}
	}
}