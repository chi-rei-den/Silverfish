using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_077",
  "name": [
    "银月城传送门",
    "Silvermoon Portal"
  ],
  "text": [
    "使一个随从获得+2/+2。随机召唤一个法力值消耗为（2）的随从。",
    "Give a minion +2/+2. Summon a random\n2-Cost minion."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39716
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_077 : SimTemplate //* Silvermoon Portal
	{
		//Give a minion +2/+2. Summon a random 2-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 2, 2);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(2), pos, ownplay);
		}
	}
}