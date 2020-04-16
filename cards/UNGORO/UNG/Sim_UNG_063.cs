using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_063",
  "name": [
    "食人草",
    "Biteweed"
  ],
  "text": [
    "<b>连击：</b>在本回合中，你每使用一张其他牌，便获得+1/+1。",
    "<b>Combo:</b> Gain +1/+1 for each other card you've played this turn."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41216
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_063 : SimTemplate //* Biteweed
	{
		//Combo: Gain +1/+1 for each other card you've played this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int buff = own.own ? p.cardsPlayedThisTurn : p.enemyAnzCards;
            p.minionGetBuffed(own, buff, buff);
        }
    }
}
