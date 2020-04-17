using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_089",
  "name": [
    "奥术傀儡",
    "Arcane Golem"
  ],
  "text": [
    "<b>战吼：</b>使你的对手获得一个法力水晶。",
    "<b>Battlecry:</b> Give your opponent a Mana Crystal."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 466
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_089 : SimCard //arcanegolem
	{

//    ansturm/. kampfschrei:/ gebt eurem gegner 1 manakristall.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
            }
            else
            {
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            }
		}


	}
}