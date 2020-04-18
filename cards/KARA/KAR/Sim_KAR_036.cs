using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_036",
  "name": [
    "奥术畸体",
    "Arcane Anomaly"
  ],
  "text": [
    "每当你施放一个法术，该随从便获得\n+1生命值。",
    "Whenever you cast a spell, give this minion\n+1 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39215
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_036 : SimTemplate //* Arcane Anomaly
	{
		//Whenever you cast a spell, give this minion +1 Health.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.Type == Chireiden.Silverfish.SimCardtype.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 0, 1);
            }
        }
	}
}