using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_001",
  "name": [
    "炎枪术",
    "Flame Lance"
  ],
  "text": [
    "对一个随从造成$8点伤害。",
    "Deal $8 damage to a minion."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2539
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_001 : SimCard //* Flame Lance
	{
		//Deal 8 damage to a minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}