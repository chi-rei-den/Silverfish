using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_339",
  "name": [
    "思维窃取",
    "Thoughtsteal"
  ],
  "text": [
    "复制你对手的牌库中的两张牌，并将其置入你的手牌。",
    "Copy 2 cards in your opponent's deck and add them to your hand."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 30
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_339 : SimTemplate //thoughtsteal
	{

//    kopiert 2 karten aus dem deck eures gegners und fügt sie eurer hand hinzu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
		}

	}
}