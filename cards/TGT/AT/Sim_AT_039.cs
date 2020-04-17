using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_039",
  "name": [
    "狂野争斗者",
    "Savage Combatant"
  ],
  "text": [
    "<b>激励：</b>在本回合中，使你的英雄获得+2攻击力。",
    "<b>Inspire:</b> Give your hero\n+2 Attack this turn."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2780
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_039 : SimCard //* Savage Combatant
	{
		//Inspire: Give your hero +2 Attack this turn.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetTempBuff(own ? p.ownHero : p.enemyHero, 2, 0);
			}
        }
	}
}