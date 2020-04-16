using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_075",
  "name": [
    "月光林地传送门",
    "Moonglade Portal"
  ],
  "text": [
    "恢复#6点生命值。随机召唤一个法力值消耗为（6）的\n随从。",
    "Restore #6 Health. Summon a random\n6-Cost minion."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39714
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_075 : SimTemplate //* Moonglade Portal
	{
		//Restore 6 Health. Summon a random 6-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(6) : p.getEnemySpellHeal(6);
            p.minionGetDamageOrHeal(target, -heal);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;			
            p.callKid(p.getRandomCardForManaMinion(6), pos, ownplay, false);
		}
	}
}