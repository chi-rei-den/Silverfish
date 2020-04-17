using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t2",
  "name": [
    "火焰之心",
    "Heart of Fire"
  ],
  "text": [
    "造成$3点伤害。",
    "Deal $3 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41590
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t2 : SimCard //* Heart of Fire
	{
		// Deal $3 damage.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}