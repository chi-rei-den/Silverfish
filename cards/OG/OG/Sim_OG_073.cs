using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_073",
  "name": [
    "菊花茶",
    "Thistle Tea"
  ],
  "text": [
    "抽一张牌。将两张该牌的复制置入你的手牌。",
    "Draw a card. Add 2 extra copies of it to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38395
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_073 : SimTemplate //* Thistle Tea
	{
		//Draw a card. Add 2 extra copies of it to your hand.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
        }
    }
}
