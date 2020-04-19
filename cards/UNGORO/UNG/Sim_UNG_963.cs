using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_963",
  "name": [
    "“太阳裂片”莱拉",
    "Lyra the Sunshard"
  ],
  "text": [
    "每当你施放一个法术，随机将一张牧师法术牌置入你的手牌。",
    "Whenever you cast a spell, add a random Priest spell to your hand."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 42046
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_963 : SimTemplate //* Lyra the Sunshard
	{
		//Whenever you cast a spell, add a random Priest spell to your hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL && wasOwnCard == triggerEffectMinion.own)
            {
                p.drawACard(Chireiden.Silverfish.SimCard.None, wasOwnCard);
            }
        }
	}
}