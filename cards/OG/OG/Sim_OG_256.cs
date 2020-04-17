using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_256",
  "name": [
    "恩佐斯的子嗣",
    "Spawn of N'Zoth"
  ],
  "text": [
    "<b>亡语：</b>使你的所有随从获得+1/+1。",
    "<b>Deathrattle:</b> Give your minions +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38797
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_256 : SimCard //* Spawn of N'Zoth
	{
		//Deathive your minions +1/+1.
		
		public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
				p.minionGetBuffed(mn, 1, 1);
            }
        }
    }
}