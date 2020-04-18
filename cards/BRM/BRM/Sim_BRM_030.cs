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
					p.drawACard(CardIds.Collectible.Warrior.ShieldBlock, m.own, true);
					p.drawACard(CardIds.Collectible.Warrior.ShieldBlock, m.own, true);
					break;
                case TAG_CLASS.WARLOCK:
					p.drawACard(CardIds.Collectible.Warlock.BaneOfDoom, m.own, true);
					p.drawACard(CardIds.Collectible.Warlock.BaneOfDoom, m.own, true);
                    break;
                case TAG_CLASS.ROGUE:
					p.drawACard(CardIds.Collectible.Rogue.Sprint, m.own, true);
					p.drawACard(CardIds.Collectible.Rogue.Sprint, m.own, true);
					break;
                case TAG_CLASS.SHAMAN:
					p.drawACard(CardIds.Collectible.Shaman.FarSight, m.own, true);
					p.drawACard(CardIds.Collectible.Shaman.FarSight, m.own, true);
					break;
                case TAG_CLASS.PRIEST:
					p.drawACard(CardIds.Collectible.Priest.Thoughtsteal, m.own, true);
					p.drawACard(CardIds.Collectible.Priest.Thoughtsteal, m.own, true);
					break;
                case TAG_CLASS.PALADIN:
					p.drawACard(CardIds.Collectible.Paladin.HammerOfWrath, m.own, true);
					p.drawACard(CardIds.Collectible.Paladin.HammerOfWrath, m.own, true);
					break;
                case TAG_CLASS.MAGE:
					p.drawACard(CardIds.Collectible.Mage.FrostNova, m.own, true);
					p.drawACard(CardIds.Collectible.Mage.FrostNova, m.own, true);
					break;
                case TAG_CLASS.HUNTER:
					p.drawACard(CardIds.Collectible.Hunter.CobraShot, m.own, true);
					p.drawACard(CardIds.Collectible.Hunter.CobraShot, m.own, true);
					break;
                case TAG_CLASS.DRUID:
					p.drawACard(CardIds.Collectible.Druid.WildGrowth, m.own, true);
					p.drawACard(CardIds.Collectible.Druid.WildGrowth, m.own, true);
                    break;
				//default:
			}
		}
	}
}