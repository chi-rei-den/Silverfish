using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_018",
  "name": [
    "烈焰喷涌",
    "Flame Geyser"
  ],
  "text": [
    "造成$2点伤害。\n将一张1/2的元素牌置入你的手牌。",
    "Deal $2 damage.\nAdd a 1/2 Elemental to your hand."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41151
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_018 : SimTemplate //* Flame Geyser
	{
		//Deal $2 damage. Add a 1/2 Elemental to your hand.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(SimCard.flameelemental, ownplay, true);
		}
	}
}