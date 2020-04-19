using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GAME_005",
  "name": [
    "幸运币",
    "The Coin"
  ],
  "text": [
    "在本回合中，获得一个法力\n水晶。",
    "Gain 1 Mana Crystal this turn only."
  ],
  "CardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "CORE",
  "collectible": null,
  "dbfId": 1746
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_GAME_005 : SimTemplate //thecoin
	{

//    erhaltet 1 manakristall nur für diesen zug.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.mana++;
            }
            else
            {
                p.mana++;
            }
        }

	}
}