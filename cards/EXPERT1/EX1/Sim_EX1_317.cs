using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_317",
  "name": [
    "感知恶魔",
    "Sense Demons"
  ],
  "text": [
    "从你的牌库中抽两张恶魔牌。",
    "Draw 2 Demons\nfrom your deck."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 860
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_317 : SimTemplate //sensedemons
	{

//    fügt eurer hand zwei zufällige dämonen aus eurem deck hinzu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(SimCard.None, ownplay);
            p.drawACard(SimCard.None, ownplay);
		}

	}
}