using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t25",
  "name": [
    "火焰之心",
    "Heart of Fire"
  ],
  "text": [
    "造成$8点伤害。",
    "Deal $8 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41621
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t25 : SimCard //* Heart of Fire
	{
		// Deal $8 damage.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}