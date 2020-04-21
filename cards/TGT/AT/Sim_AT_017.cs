using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_017",
  "name": [
    "暮光守护者",
    "Twilight Guardian"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便获得+1攻击力和<b>嘲讽</b>。",
    "<b>Battlecry:</b> If you're holding a Dragon, gain +1 Attack and <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2569
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_017 : SimTemplate //* Twilight Guardian
	{
		//Battlecry: If you're holding a Dragon, gain +1 Attack and Taunt.

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
				if(dragonInHand)
				{
					p.minionGetBuffed(m, 1, 0);
					m.taunt = true;
                    p.anzOwnTaunt++;
                }
			}
			else
			{
				if (p.enemyAnzCards >= 2)
				{
					p.minionGetBuffed(m, 1, 0);
					m.taunt = true;
                    p.anzEnemyTaunt++;
                }					
			}
        }
    }
}