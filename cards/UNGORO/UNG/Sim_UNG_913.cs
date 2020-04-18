using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_913",
  "name": [
    "托维尔守卫",
    "Tol'vir Warden"
  ],
  "text": [
    "<b>战吼：</b>从你的牌库中抽两张法力值消耗为（1）的随从牌。",
    "<b>Battlecry:</b> Draw two 1-Cost minions from your deck."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41354
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_913 : SimTemplate //* Tol'vir Warden
	{
		//Battlecry: Draw two 1-Cost minions from your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                        p.drawACard(Chireiden.Silverfish.SimCard.lepergnome, own.own);
                        p.drawACard(Chireiden.Silverfish.SimCard.lepergnome, own.own);
            }
            else p.enemyAnzCards++;
		}
	}
}