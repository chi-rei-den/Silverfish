using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_071",
  "name": [
    "阿莱克丝塔萨的勇士",
    "Alexstrasza's Champion"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便获得+1攻击力和<b>冲锋</b>。",
    "<b>Battlecry:</b> If you're holding a Dragon, gain +1 Attack and <b>Charge</b>."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2758
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_071 : SimCard //* Alexstrasza's Champion
	{
		//Battlecry: If you're holding a Dragon, gain +1 Attack and Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
			if(m.own)
			{
				bool dragonInHand = false;
				foreach (Handmanager.Handcard hc in p.owncards)
				{
					if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
					{
						dragonInHand = true;
						break;
					}
				}
				if(dragonInHand)
				{
					p.minionGetBuffed(m, 1, 0);
					p.minionGetCharge(m);

				}
			}
			else
			{
				if (p.enemyAnzCards >= 2)
				{
					p.minionGetBuffed(m, 1, 0);
					p.minionGetCharge(m);
				}
			}
        }
    }
}