using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_059",
  "name": [
    "神勇弓箭手",
    "Brave Archer"
  ],
  "text": [
    "<b>激励：</b>如果你没有其他手牌，则对敌方英雄造成2点伤害。",
    "<b>Inspire:</b> If your hand is empty, deal 2 damage to the enemy hero."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2642
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_059 : SimTemplate //* Brave Archer
	{
		//Inspire: If your hand is empty, deal 2 damage to the enemy hero.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
	            int cardsCount = (own) ? p.owncards.Count : p.enemyAnzCards;
				if (cardsCount <= 0)
				{
					p.minionGetDamageOrHeal(own ? p.enemyHero : p.ownHero, 2);
				}
			}
        }
	}
}