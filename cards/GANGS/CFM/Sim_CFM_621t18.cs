using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_621t18",
  "name": [
    "邪能花",
    "Felbloom"
  ],
  "text": [
    "对所有随从造成$4点伤害。",
    "Deal $4 damage to all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "GANGS",
  "collectible": null,
  "dbfId": 41607
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_621t18 : SimCard //* Felbloom
	{
		// Deal $4 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.allMinionsGetDamage(dmg);
        }
    }
}