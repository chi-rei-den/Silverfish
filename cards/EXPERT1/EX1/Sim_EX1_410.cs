using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_410",
  "name": [
    "盾牌猛击",
    "Shield Slam"
  ],
  "text": [
    "你每有1点护甲值，便对一个随从造成1点伤害。",
    "Deal 1 damage to a minion for each Armor you have."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 546
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_410 : SimCard //shieldslam
	{

//    fügt einem diener für jeden eurer rüstungspunkte 1 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{


            int dmg = (ownplay) ? p.getSpellDamageDamage(p.ownHero.armor) : p.getEnemySpellDamageDamage(p.enemyHero.armor);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}