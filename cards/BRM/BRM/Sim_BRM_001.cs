using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_001",
  "name": [
    "严正警戒",
    "Solemn Vigil"
  ],
  "text": [
    "抽两张牌。在本回合中每有一个随从死亡，该牌的法力值消耗就减少（1）点。",
    "Draw 2 cards. Costs (1) less for each minion that died this turn."
  ],
  "CardClass": "PALADIN",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2274
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_001 : SimTemplate //* Solemn Vigil
	{
		// Draw 2 cards. Costs (1) less for each minion that died this turn.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
		}
	}
}