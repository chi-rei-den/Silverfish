using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_032",
  "name": [
    "结晶预言者",
    "Crystalline Oracle"
  ],
  "text": [
    "<b>亡语：</b>复制你对手的牌库中的一张牌，并将其置入你的手牌。",
    "[x]<b>Deathrattle:</b> Copy a card\nfrom your opponent's deck\n and add it to your hand."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41173
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_032 : SimCard //* Crystalline Oracle
	{
		//Deathrattle: Copy a card from your opponent's deck and add it to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.None, m.own, true);
        }
	}
}