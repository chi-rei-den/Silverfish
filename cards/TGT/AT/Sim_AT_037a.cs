using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_037a",
  "name": [
    "缠人根须",
    "Grasping Roots"
  ],
  "text": [
    "造成$2点伤害。",
    "Deal $2 damage."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2789
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_037a : SimTemplate //* Living Roots
	{
		//Deal $2 damage.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}