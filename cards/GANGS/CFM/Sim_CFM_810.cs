using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_810",
  "name": [
    "野猪骑士蕾瑟兰",
    "Leatherclad Hogleader"
  ],
  "text": [
    "<b>战吼：</b>如果你的对手拥有6张或者更多手牌，便获得<b>冲锋</b>。",
    "<b>Battlecry:</b> If your opponent has 6 or more cards in hand, gain <b>Charge</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40613
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_810 : SimCard //* Leatherclad Hogleader
	{
		// Battlecry: If your opponent has 6 or more cards in hand, gain Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int anz = (m.own) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 6) p.minionGetCharge(m);
        }
    }
}