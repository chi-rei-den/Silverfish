using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_062",
  "name": [
    "虚空幽龙史学家",
    "Netherspite Historian"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便<b>发现</b>一张龙牌。",
    "<b>Battlecry:</b> If you're holding a Dragon, <b>Discover</b>\na Dragon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39554
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_062 : SimTemplate //* Netherspite Historian
	{
		//Battlecry: If you're holding a Dragon, Discover a Dragon.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if(own.own)
			{
				bool dragonInHand = false;
				foreach (Handmanager.Handcard hc in p.owncards)
				{
					if (hc.card.Race == Race.DRAGON)
					{
						dragonInHand = true;
						break;
					}
				}
				if(dragonInHand)
				{
					p.drawACard(CardIds.Collectible.Neutral.DrakonidCrusher, own.own, true);
                }
			}
			else
			{
				if (p.enemyAnzCards >= 2)
				{
					p.drawACard(CardIds.Collectible.Neutral.DrakonidCrusher, own.own, true);
                }					
			}
        }
    }
}