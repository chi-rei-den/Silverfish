using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_065",
  "name": [
    "火山药水",
    "Volcanic Potion"
  ],
  "text": [
    "对所有随从造成$2点伤害。",
    "Deal $2 damage to all minions."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40297
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_065 : SimTemplate //* Volcanic Potion
	{
		// Deal 2 damage to all minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionsGetDamage(dmg);
        }
    }
}