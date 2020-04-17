using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_184",
  "name": [
    "追踪术",
    "Tracking"
  ],
  "text": [
    "检视你的牌库顶的三张牌，将其中一张置入手牌，弃掉其余牌。",
    "Look at the top 3 cards of your deck. Draw one and discard the others."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1047
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DS1_184 : SimCard //tracking
	{

//    schaut euch die drei obersten karten eures decks an. zieht eine davon und werft die anderen beiden ab.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //TODO NOT SUPPORTED YET
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            //p.evaluatePenality += 100;
		}

	}
}