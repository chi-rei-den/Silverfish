using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_934t2",
  "name": [
    "死吧，虫子！",
    "DIE, INSECT!"
  ],
  "text": [
    "<b>英雄技能</b>\n随机对一个敌人造成$8点伤害。",
    "<b>Hero Power</b>\nDeal $8 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41940
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_934t2 : SimTemplate //* DIE, INSECT!
	{
		// Hero Power: Deal 8 damage to a random enemy.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(8) : p.getEnemyHeroPowerDamage(8);
            if (ownplay)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(dmg);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.HighAttack); //damage the Highest (pessimistic)
                if (target == null) target = p.ownHero;
            }
            p.minionGetDamageOrHeal(target, dmg, true);
        }
	}
}