using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_057",
  "name": [
    "象牙骑士",
    "Ivory Knight"
  ],
  "text": [
    "<b>战吼：</b><b>发现</b>一张法术牌。为你的英雄恢复等同于其法力值消耗的生命值。",
    "[x]<b>Battlecry:</b> <b>Discover</b> a spell.\nRestore Health to your hero\nequal to its Cost."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39439
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_057 : SimTemplate //* Ivory Knight
	{
		//Battlecry: Discover a spell. Restore Health to your hero equal to its Cost.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.thecoin, own.own, true);
			int heal = (own.own) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
		}
	}
}