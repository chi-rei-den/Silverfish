using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_086",
  "name": [
    "禁忌烈焰",
    "Forbidden Flame"
  ],
  "text": [
    "消耗你所有的法力值，对一个随从造成等同于所消耗法力值数量的伤害。",
    "Spend all your Mana. Deal that much damage to a minion."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 0,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38413
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_086 : SimTemplate //* Forbidden Flame
	{
		//Spend all your Mana. Deal that much damage to a minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(p.mana) : p.getEnemySpellDamageDamage(p.enemyMaxMana);
            p.minionGetDamageOrHeal(target, dmg);
			if (ownplay) p.mana = 0;
		}
	}
}