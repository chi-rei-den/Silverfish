using HearthDb.Enums;
using HearthDb;
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
  "CardClass": "NEUTRAL",
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
            CardClass opponentHeroClass = (m.own) ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case CardClass.WARRIOR:
					p.drawACard(CardIds.Collectible.Warrior.ShieldBlock, m.own, true);
					p.drawACard(CardIds.Collectible.Warrior.ShieldBlock, m.own, true);
					break;
                case CardClass.WARLOCK:
					p.drawACard(CardIds.Collectible.Warlock.BaneOfDoom, m.own, true);
					p.drawACard(CardIds.Collectible.Warlock.BaneOfDoom, m.own, true);
                    break;
                case CardClass.ROGUE:
					p.drawACard(CardIds.Collectible.Rogue.Sprint, m.own, true);
					p.drawACard(CardIds.Collectible.Rogue.Sprint, m.own, true);
					break;
                case CardClass.SHAMAN:
					p.drawACard(CardIds.Collectible.Shaman.FarSight, m.own, true);
					p.drawACard(CardIds.Collectible.Shaman.FarSight, m.own, true);
					break;
                case CardClass.PRIEST:
					p.drawACard(CardIds.Collectible.Priest.Thoughtsteal, m.own, true);
					p.drawACard(CardIds.Collectible.Priest.Thoughtsteal, m.own, true);
					break;
                case CardClass.PALADIN:
					p.drawACard(CardIds.Collectible.Paladin.HammerOfWrath, m.own, true);
					p.drawACard(CardIds.Collectible.Paladin.HammerOfWrath, m.own, true);
					break;
                case CardClass.MAGE:
					p.drawACard(CardIds.Collectible.Mage.FrostNova, m.own, true);
					p.drawACard(CardIds.Collectible.Mage.FrostNova, m.own, true);
					break;
                case CardClass.HUNTER:
					p.drawACard(CardIds.Collectible.Hunter.CobraShot, m.own, true);
					p.drawACard(CardIds.Collectible.Hunter.CobraShot, m.own, true);
					break;
                case CardClass.DRUID:
					p.drawACard(CardIds.Collectible.Druid.WildGrowth, m.own, true);
					p.drawACard(CardIds.Collectible.Druid.WildGrowth, m.own, true);
                    break;
				//default:
			}
		}
	}
}