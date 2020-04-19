using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_015",
  "name": [
    "策反",
    "Convert"
  ],
  "text": [
    "将一个敌方随从的一张复制置入你的手牌。",
    "Put a copy of an enemy minion into your hand."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2563
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_015 : SimTemplate //* Convert
	{
		//Put a copy of an enemy minion into your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(target.handcard.card.CardId, ownplay, true);
        }
    }
}
