using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_044",
  "name": [
    "腐根",
    "Mulch"
  ],
  "text": [
    "消灭一个随从。随机将一张随从牌置入对手的手牌。",
    "Destroy a minion.\nAdd a random minion to your opponent's hand."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2793
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_044 : SimTemplate //* Mulch
	{
		//Destroy a minion. Add a random minion to your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.minionGetDestroyed(target);
            p.drawACard(CardDB.cardIDEnum.None, !ownplay, true);
        }
    }
}