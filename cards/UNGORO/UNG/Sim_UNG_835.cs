using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_835",
  "name": [
    "聒噪的挖掘者",
    "Chittering Tunneler"
  ],
  "text": [
    "<b>战吼：</b>\n<b>发现</b>一张法术牌。对你的英雄造成等同于其法力值消耗的伤害。",
    "<b>Battlecry:</b> <b>Discover</b> a spell. Deal damage to your hero equal to its Cost."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41875
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_835 : SimTemplate //* Chittering Tunneler
	{
		//Battlecry: Discover a spell. Deal damage to your hero equal to its Cost.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.thecoin, own.own, true);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 3);
		}
	}
}