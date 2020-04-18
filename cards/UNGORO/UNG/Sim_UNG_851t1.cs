using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_851t1",
  "name": [
    "安戈洛卡牌包",
    "Un'Goro Pack"
  ],
  "text": [
    "将五张<b>勇闯安戈洛</b>系列的卡牌置入你的手牌。",
    "Add 5 <b>Journey to Un'Goro</b> cards to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41491
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_851t1 : SimTemplate //* Un'Goro Pack
	{
		//Add 5 Journey to Un'Goro cards to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
        }
    }
}