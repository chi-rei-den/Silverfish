using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX15_02H",
  "name": [
    "冰霜冲击",
    "Frost Blast"
  ],
  "text": [
    "<b>英雄技能</b>\n对敌方英雄造成3点\n伤害，并使其\n<b>冻结</b>。",
    "<b>Hero Power</b>\nDeal 3 damage to the enemy hero and <b>Freeze</b> it."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2148
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX15_02H : SimCard //* frostblast heroic
	{
        //Hero Power: Deal 3 damage to the enemy hero and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
            p.minionGetFrozen(target);
        }
	}
}