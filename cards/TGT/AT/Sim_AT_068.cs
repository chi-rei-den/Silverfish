using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_068",
  "name": [
    "加固",
    "Bolster"
  ],
  "text": [
    "使你具有<b>嘲讽</b>的随从获得+2/+2。",
    "Give your <b>Taunt</b> minions +2/+2."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2754
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_068 : SimTemplate //* Bolster
	{
		//Give your Taunt minions +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
				if (m.taunt) p.minionGetBuffed(m, 2, 2);
            }
        }
    }
}
