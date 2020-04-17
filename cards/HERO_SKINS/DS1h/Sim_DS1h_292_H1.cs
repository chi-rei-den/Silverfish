using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1h_292_H1",
  "name": [
    "稳固射击",
    "Steady Shot"
  ],
  "text": [
    "<b>英雄技能</b>\n对敌方英雄造成$2点伤害。",
    "<b>Hero Power</b>\nDeal $2 damage to the enemy hero."
  ],
  "cardClass": "HUNTER",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "HERO_SKINS",
  "collectible": null,
  "dbfId": 2833
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DS1h_292_H1 : SimCard //* Steady Shot
	{
		//Hero Power: Deal 2 damage to the enemy hero.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            if (target == null) target = ownplay ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}