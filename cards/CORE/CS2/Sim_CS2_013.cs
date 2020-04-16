using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_013",
  "name": [
    "野性成长",
    "Wild Growth"
  ],
  "text": [
    "获得一个空的法力水晶。",
    "Gain an empty Mana Crystal."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1124
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_013 : SimTemplate //wildgrowth
	{

//    erhaltet einen leeren manakristall.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownMaxMana < 10)
                {
                    p.ownMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, true, true);
                }

            }
            else
            {
                if (p.enemyMaxMana < 10)
                {
                    p.enemyMaxMana++;
                }
                else
                {
                    p.drawACard(CardDB.cardName.excessmana, false, true);
                }
            }
		}

	}
}