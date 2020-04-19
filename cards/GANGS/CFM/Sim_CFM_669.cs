using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_669",
  "name": [
    "穴居人强盗",
    "Burgly Bully"
  ],
  "text": [
    "每当你的对手施放一个法术，将一个幸运币置入你的手牌。",
    "Whenever your opponent casts a spell, add a Coin to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40954
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_669 : SimTemplate //* Burgly Bully
	{
		// Whenever your opponent casts a spell, add a Coin to your hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.drawACard(CardIds.NonCollectible.Neutral.TheCoin, triggerEffectMinion.own);
            }
        }
    }
}