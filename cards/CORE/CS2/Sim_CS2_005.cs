using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_005",
  "name": [
    "爪击",
    "Claw"
  ],
  "text": [
    "使你的英雄获得2点护甲值，并在本回合中获得\n+2攻击力。",
    "Give your hero +2 Attack this turn. Gain 2 Armor."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1050
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_005 : SimCard //claw
	{

//    verleiht eurem helden +2 angriff in diesem zug und 2 rüstung.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 2);
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 2);
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }
		}

	}
}