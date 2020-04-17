using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_570",
  "name": [
    "撕咬",
    "Bite"
  ],
  "text": [
    "使你的英雄获得4点护甲值，并在本回合中获得\n+4攻击力。",
    "Give your hero +4 Attack this turn. Gain 4 Armor."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 577
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_570 : SimCard //bite
	{

//    verleiht eurem helden +4 angriff in diesem zug und 4 rüstung.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 4, 0);
                p.minionGetArmor(p.ownHero, 4);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 4, 0);
                p.minionGetArmor(p.enemyHero, 4);

            }
		}

	}
}