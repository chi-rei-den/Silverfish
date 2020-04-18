using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_030",
  "name": [
    "奈法利安",
    "Nefarian"
  ],
  "text": [
    "<b>战吼：</b>随机将两张<i>（你对手职业的）</i>法术牌置入你的手牌。",
    "<b>Battlecry:</b> Add 2 random spells to your hand <i>(from your opponent's class)</i>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2261
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_030 : SimTemplate //* Nefarian
	{
		// Battlecry: Add 2 random spells to your hand (from your opponent's class).
		
		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            TAG_CLASS opponentHeroClass = (m.own) ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case TAG_CLASS.WARRIOR:
					p.drawACard(Chireiden.Silverfish.SimCard.shieldblock, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.shieldblock, m.own, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(Chireiden.Silverfish.SimCard.baneofdoom, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.baneofdoom, m.own, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(Chireiden.Silverfish.SimCard.sprint, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.sprint, m.own, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(Chireiden.Silverfish.SimCard.farsight, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.farsight, m.own, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(Chireiden.Silverfish.SimCard.thoughtsteal, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.thoughtsteal, m.own, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(Chireiden.Silverfish.SimCard.hammerofwrath, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.hammerofwrath, m.own, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(Chireiden.Silverfish.SimCard.frostnova, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.frostnova, m.own, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(Chireiden.Silverfish.SimCard.cobrashot, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.cobrashot, m.own, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(Chireiden.Silverfish.SimCard.wildgrowth, m.own, true);
					p.drawACard(Chireiden.Silverfish.SimCard.wildgrowth, m.own, true);
                    break;
				//default:
			}
		}
	}
}