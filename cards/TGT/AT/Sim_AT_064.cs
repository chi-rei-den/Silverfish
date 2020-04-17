using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_064",
  "name": [
    "怒袭",
    "Bash"
  ],
  "text": [
    "造成$3点伤害。获得3点\n护甲值。",
    "Deal $3 damage.\nGain 3 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2729
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_064 : SimCard //* Bash
	{
		//Deal 3 Damage. Gain 3 Armor.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 3);			
		}
	}
}