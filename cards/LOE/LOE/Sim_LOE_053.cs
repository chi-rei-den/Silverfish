using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_053",
  "name": [
    "西风灯神",
    "Djinni of Zephyrs"
  ],
  "text": [
    "在你对一个其他友方随从施放法术后，将法术效果复制在此随从身上。",
    "After you cast a spell on another friendly minion, cast a copy of it on this one."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2925
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_053 : SimTemplate //* Djinni of Zephyrs
	{
		//Whenever you cast a spell on another friendly minion, cast a copy of it on this one.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == Chireiden.Silverfish.SimCardtype.SPELL && hc.target != null && hc.target.own == wasOwnCard)
            {
                if (hc.target.own == triggerEffectMinion.own && hc.target.entitiyID != triggerEffectMinion.entitiyID)
                {
                    hc.card.sim_card.onCardPlay(p, wasOwnCard, triggerEffectMinion, hc.extraParam2);
                }
            }
        }
    }
}