using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_179",
  "name": [
    "炽炎蝙蝠",
    "Fiery Bat"
  ],
  "text": [
    "<b>亡语：</b>随机对一个敌人造成1点伤害。",
    "<b>Deathrattle:</b> Deal 1 damage to a random enemy."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38584
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_179 : SimTemplate //* Fiery Bat
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
                target = p.searchRandomMinion(p.ownMinions, SearchMode.LowHealth); //(pessimistic)
                if (target == null) target = p.ownHero;
            }
            p.minionGetDamageOrHeal(target, 1);
        }
    }
}