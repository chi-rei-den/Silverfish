using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_816",
  "name": [
    "兔妖教头",
    "Virmen Sensei"
  ],
  "text": [
    "<b>战吼：</b>使一个友方野兽获得+2/+2。",
    "<b>Battlecry:</b> Give a friendly Beast +2/+2."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40641
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_816 : SimCard //* Virmen Sensei
	{
		// Battlecry: Give a friendly Beast +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 2, 2);
        }
    }
}