using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_095",
  "name": [
    "加基森拍卖师",
    "Gadgetzan Auctioneer"
  ],
  "text": [
    "每当你施放一个法术，抽一张牌。",
    "Whenever you cast a spell, draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 932
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_095 : SimTemplate //gadgetzanauctioneer
	{

//    zieht jedes mal eine karte, wenn ihr einen zauber wirkt.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL && wasOwnCard == triggerEffectMinion.own)
            {
                p.drawACard(Chireiden.Silverfish.SimCard.None, wasOwnCard);
            }

        }

	}
}