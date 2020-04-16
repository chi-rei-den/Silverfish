using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_027",
  "name": [
    "异变",
    "Evolve"
  ],
  "text": [
    "随机将你的\n所有随从变形成为法力值消耗增加（1）点的随从。",
    "Transform your minions into random minions that cost (1) more."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38266
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_027 : SimTemplate //* Evolve
	{
		//Transform your minions into random minions that cost (1) more.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{            
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp )
            {
                
                
                p.minionTransform(m, p.getRandomCardForManaMinion(m.handcard.card.cost + 1));
            }
		}
	}
}