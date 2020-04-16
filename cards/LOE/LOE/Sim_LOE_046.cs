using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_046",
  "name": [
    "巨型蟾蜍",
    "Huge Toad"
  ],
  "text": [
    "<b>亡语：</b>随机对一个敌人造成1点伤害。",
    "<b>Deathrattle:</b> Deal 1 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2918
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_046 : SimTemplate //* Huge Toad
	{
		//Deathrattle: Deal 1 damage to a random enemy.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = null;

            if (m.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(1);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchLowestHP); //(pessimistic)
                if (target == null) target = p.ownHero;
            }
			p.minionGetDamageOrHeal(target, 1);
        }
    }
}