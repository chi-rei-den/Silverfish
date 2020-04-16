using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_037",
  "name": [
    "始祖龟执盾者",
    "Tortollan Shellraiser"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>随机使一个友方随从获得+1/+1。",
    "[x]<b>Taunt</b>\n<b>Deathrattle:</b> Give a random\n friendly minion +1/+1."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41180
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_037 : SimTemplate //* Tortollan Shellraiser
	{
		//Taunt. Deathrattle: Give a random friendly minion +1/+1.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack);
			if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}