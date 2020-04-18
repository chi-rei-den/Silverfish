using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_161",
  "name": [
    "自然平衡",
    "Naturalize"
  ],
  "text": [
    "消灭一个随从，你的对手抽两张牌。",
    "Destroy a minion.\nYour opponent draws 2 cards."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 233
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_161 : SimTemplate //naturalize
	{

//    vernichtet einen diener. euer gegner zieht 2 karten.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
            p.drawACard(Chireiden.Silverfish.SimCard.None, !ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, !ownplay);
		}

	}
}