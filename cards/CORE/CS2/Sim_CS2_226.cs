using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_226",
  "name": [
    "霜狼督军",
    "Frostwolf Warlord"
  ],
  "text": [
    "<b>战吼：</b>战场上每有一个其他友方随从，便获得+1/+1。",
    "<b>Battlecry:</b> Gain +1/+1 for each other friendly minion on the battlefield."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 496
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_226 : SimTemplate //* Frostwolf Warlord
	{
        // Battlecry: Gain +1/+1 for each other friendly minion on the battlefield.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int buff = (own.own) ? p.ownMinions.Count - 1 : p.enemyMinions.Count - 1;
            p.minionGetBuffed(own, buff, buff);
		}
	}
}