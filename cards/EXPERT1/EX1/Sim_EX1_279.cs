using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_279",
  "name": [
    "炎爆术",
    "Pyroblast"
  ],
  "text": [
    "造成$10点伤害。",
    "Deal $10 damage."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 10,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1087
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_279 : SimCard //pyroblast
	{

//    verursacht $10 schaden.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(10) : p.getEnemySpellDamageDamage(10);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}