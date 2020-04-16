using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_013",
  "name": [
    "快速射击",
    "Quick Shot"
  ],
  "text": [
    "造成$3点伤害。\n如果你没有其他手牌，则抽一张牌。",
    "Deal $3 damage.\nIf your hand is empty, draw a card."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2260
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_013 : SimTemplate //* Quick Shot
	{
		// Deal 3 damage. If your hand is empty, draw a card.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
			
			int cardsCount = (ownplay) ? p.owncards.Count : p.enemyAnzCards;
            if (cardsCount <= 0) p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}
	}
}