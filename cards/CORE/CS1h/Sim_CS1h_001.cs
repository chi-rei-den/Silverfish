using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS1h_001",
  "name": [
    "次级治疗术",
    "Lesser Heal"
  ],
  "text": [
    "<b>英雄技能</b>\n恢复#2点生命值。",
    "<b>Hero Power</b>\nRestore #2 Health."
  ],
  "CardClass": "PRIEST",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 479
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS1h_001 : SimTemplate //lesserheal
	{

//    heldenfähigkeit/\nstellt 2 leben wieder her.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = 2;
            if (ownplay)
            {
                if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0) heal = -heal;
                if (p.doublepriest >= 1) heal *= (2 * p.doublepriest);
            }
            else
            {
                if (p.anzEnemyAuchenaiSoulpriest >= 1) heal = -heal;
                if (p.enemydoublepriest >= 1) heal *= (2 * p.enemydoublepriest);
            }
            p.minionGetDamageOrHeal(target, -heal);
            
            
		}

	}
}