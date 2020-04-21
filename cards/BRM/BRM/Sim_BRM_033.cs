using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_033",
  "name": [
    "黑翼技师",
    "Blackwing Technician"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便获得+1/+1。",
    "<b>Battlecry:</b> If you're holding a Dragon, gain +1/+1."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2408
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_033 : SimTemplate //* Blackwing Technician
    {
        // Battlecry: If you're holding a Dragon, gain +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			if(m.own)
			{
				bool dragonInHand = false;
				foreach (Handcard hc in p.owncards)
				{
					if (hc.card.Race == Race.DRAGON)
					{
						dragonInHand = true;
						break;
					}
				}
				if(dragonInHand) p.minionGetBuffed(m, 1, 1);
			}
			else
			{
                if (p.enemyAnzCards >= 2) p.minionGetBuffed(m, 1, 1);
			}
        }
    }
}