using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_056",
  "name": [
    "生命分流",
    "Life Tap"
  ],
  "text": [
    "<b>英雄技能</b>\n抽一张牌并受到$2点伤害。",
    "<b>Hero Power</b>\nDraw a card and take $2 damage."
  ],
  "cardClass": "WARLOCK",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 300
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_056 : SimTemplate //lifetap
	{

//    heldenfähigkeit/\nzieht eine karte und erleidet 2 schaden.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);

            int dmg = 2;
            if (ownplay)
            {
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
                p.minionGetDamageOrHeal(p.ownHero, dmg);
            }
            else
            {
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
                p.minionGetDamageOrHeal(p.enemyHero, dmg);
            }
        }


	}
}