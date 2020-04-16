using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_076",
  "name": [
    "火焰之地传送门",
    "Firelands Portal"
  ],
  "text": [
    "造成$5点伤害。随机召唤一个法力值消耗为（5）的随从。",
    "Deal $5 damage. Summon a random\n5-Cost minion."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 7,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39715
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_076 : SimTemplate //* Firelands Portal
	{
		//Deal 5 damage. Summon a random 5-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(5), pos, ownplay);
		}
	}
}