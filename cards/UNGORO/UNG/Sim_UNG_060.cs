using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_060",
  "name": [
    "拟态豆荚",
    "Mimic Pod"
  ],
  "text": [
    "抽一张牌，然后将一张它的复制置入你的手牌。",
    "Draw a card, then add a copy of it to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41212
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_060 : SimTemplate //* Mimic Pod
	{
		//Draw a card, then add a copy of it to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
		}
	}
}