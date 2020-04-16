using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX6_02",
  "name": [
    "死灵光环",
    "Necrotic Aura"
  ],
  "text": [
    "<b>英雄技能</b>\n对敌方英雄造成3点伤害。",
    "<b>Hero Power</b>\nDeal 3 damage to the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1862
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX6_02 : SimTemplate //* Necrotic Aura
	{
		//Hero Power: Deal 3 damage to the enemy hero.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
		}
	}
}