using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_091",
  "name": [
    "铁炉堡传送门",
    "Ironforge Portal"
  ],
  "text": [
    "获得4点护甲值。随机召唤一个法力值消耗为（4）的\n随从。",
    "Gain 4 Armor.\nSummon a random\n4-Cost minion."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39747
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_091 : SimCard //* Ironforge Portal
	{
		//Gain 4 Armor. Summon a random 4-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 4);	
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(4), pos, ownplay);
		}
	}
}