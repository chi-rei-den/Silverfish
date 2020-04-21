using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_023",
  "name": [
    "虚空碾压者",
    "Void Crusher"
  ],
  "text": [
    "<b>激励：</b>随机消灭每个玩家的一个随从。",
    "<b>Inspire:</b> Destroy a random minion for each player."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2537
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_023 : SimTemplate //* Void Crusher
	{
		//Inspire: Destroy a random minion for each player.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                Minion found = p.searchRandomMinion(p.enemyMinions, SearchMode.LowHealth);
                if (found != null)
                {
                    p.minionGetDestroyed(found);
                }
				found = p.searchRandomMinion(p.ownMinions, SearchMode.HighHealth, SearchMode.LowAttack);
                if (found != null)
                {
                    p.minionGetDestroyed(found);
                }
            }
        }
	}
}