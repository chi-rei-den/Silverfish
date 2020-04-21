using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_818",
  "name": [
    "不稳定的元素",
    "Volatile Elemental"
  ],
  "text": [
    "<b>亡语：</b>随机对一个敌方随从造成3点伤害。",
    "<b>Deathrattle:</b> Deal 3 damage to a random enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41524
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_818 : SimTemplate //* Volatile Elemental
	{
		//Deathrattle: Deal 3 damage to a random enemy minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = null;
            if (m.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(3, true);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, SearchMode.HighAttack); //damage the Highest (pessimistic)
            }
            if (target != null) p.minionGetDamageOrHeal(target, 3);
        }
    }
}