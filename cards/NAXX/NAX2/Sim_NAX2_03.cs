using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX2_03",
  "name": [
    "火焰之雨",
    "Rain of Fire"
  ],
  "text": [
    "<b>英雄技能</b>\n你的对手每有一张手牌，便发射一枚飞弹。",
    "<b>Hero Power</b>\nFire a missile for each card in your opponent's hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1840
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX2_03 : SimTemplate //Rain of Fire
	{

//  Hero Power (Normal): Fire a missile for each card in your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 1;
			int cardCount = 0;
            if (ownplay)
            {
				cardCount = p.enemyAnzCards;
				dmg += p.ownHeroPowerExtraDamage;
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
            }
            else
            {
				cardCount = p.owncards.Count;
				dmg += p.enemyHeroPowerExtraDamage;
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
            }
						
            for (int i = 0; i < cardCount; i++)
            {
				target = (ownplay)? p.searchRandomMinion(p.enemyMinions, SearchMode.searchHighAttackLowHP) : p.searchRandomMinion(p.ownMinions, SearchMode.searchHighAttackLowHP);
				if (target == null) target = (ownplay) ? p.enemyHero : p.ownHero;
				p.minionGetDamageOrHeal(target, dmg);
            }
        }
	}
}