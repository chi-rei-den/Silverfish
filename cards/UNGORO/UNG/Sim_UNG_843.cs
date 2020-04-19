using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_843",
  "name": [
    "沃拉斯",
    "The Voraxx"
  ],
  "text": [
    "在你对该随从施放一个法术后，召唤一个1/1的植物，并对其施放相同的法术。",
    "[x]After you cast a spell on\nthis minion, summon a\n1/1 Plant and cast\nanother copy on it."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41913
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_843 : SimTemplate //* The Voraxx
	{
		//After you cast a spell on this minion, summon a 1/1 Plant and cast another copy on it.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.PlantToken; //Plant
        
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL && hc.target != null && hc.target.entitiyID == triggerEffectMinion.entitiyID)
            {
                List<Minion> tmp = triggerEffectMinion.own ? p.ownMinions : p.enemyMinions;

                if (tmp.Count < 7)
                {
                    p.callKid(kid, triggerEffectMinion.zonepos, triggerEffectMinion.own);
                    hc.card.Simulator.onCardPlay(p, wasOwnCard, tmp[triggerEffectMinion.zonepos], hc.extraParam2);
                }
            }
        }
    }
}