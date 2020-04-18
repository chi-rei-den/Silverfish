using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA13_4H",
  "name": [
    "狂野魔法",
    "Wild Magic"
  ],
  "text": [
    "<b>英雄技能</b>\n随机将一张你对手职业的法术牌置入你的手牌。",
    "<b>Hero Power</b>\nPut a random spell from your opponent's class into your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2467
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA13_4H : SimTemplate //* Wild Magic
	{
		// Hero Power: Put a random spell from your opponent's class into your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            TAG_CLASS opponentHeroClass = ownplay ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARRIOR:
					p.drawACard(Chireiden.Silverfish.SimCard.shieldblock, ownplay, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(Chireiden.Silverfish.SimCard.baneofdoom, ownplay, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(Chireiden.Silverfish.SimCard.sprint, ownplay, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(Chireiden.Silverfish.SimCard.farsight, ownplay, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(Chireiden.Silverfish.SimCard.thoughtsteal, ownplay, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(Chireiden.Silverfish.SimCard.hammerofwrath, ownplay, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(Chireiden.Silverfish.SimCard.frostnova, ownplay, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(Chireiden.Silverfish.SimCard.cobrashot, ownplay, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(Chireiden.Silverfish.SimCard.wildgrowth, ownplay, true);
                    break;
				//default:
			}
		}
	}
}