using Chireiden.Silverfish;
using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_606",
  "name": [
    "盾牌格挡",
    "Shield Block"
  ],
  "text": [
    "获得5点护甲值。抽一张牌。",
    "Gain 5 Armor.\nDraw a card."
  ],
  "CardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1023
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_606 : SimTemplate //shieldblock
	{

//    erhaltet 5 rüstung. zieht eine karte.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 5);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 5);
            }
            p.drawACard(SimCard.None, ownplay);
		}

	}
}