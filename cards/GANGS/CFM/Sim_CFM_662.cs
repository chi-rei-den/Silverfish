using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_662",
  "name": [
    "龙息药水",
    "Dragonfire Potion"
  ],
  "text": [
    "对除了龙之外的所有随从造成$5点伤害。",
    "[x]Deal $5 damage to all\nminions except Dragons."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40938
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_662 : SimTemplate //* Dragonfire Potion
	{
		// Deal 5 damage to all minions except Dragons.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            foreach (Minion m in p.ownMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.DRAGON) p.minionGetDamageOrHeal(m, dmg);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.DRAGON) p.minionGetDamageOrHeal(m, dmg);
            }
        }
    }
}