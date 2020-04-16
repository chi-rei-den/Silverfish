using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_073",
  "name": [
    "大漩涡传送门",
    "Maelstrom Portal"
  ],
  "text": [
    "对所有敌方随从造成$1点伤害。随机召唤一个法力值消耗为（1）的随从。",
    "Deal $1 damage to all enemy minions. Summon a random\n1-Cost minion."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39712
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_073 : SimTemplate //* Maelstrom Portal
	{
		//Deal 1 damage to all enemy minions. Summon a random 1-Cost minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
			
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(1), pos, ownplay);
		}
	}
}