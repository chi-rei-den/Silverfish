using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_064",
  "name": [
    "黑金大亨",
    "Blubber Baron"
  ],
  "text": [
    "每当你召唤一个具有<b>战吼</b>的随从时，便使这张牌（在你手牌中时）获得+1/+1。",
    "Whenever you summon a <b>Battlecry</b> minion while this is in your hand, gain +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40294
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_064 : SimTemplate //* Blubber Baron
	{
		// Whenever you summon a Battlecry minion while this is in your hand, gain +1/+1.

        //handled

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            if (hc.card.battlecry && hc.card.type == Chireiden.Silverfish.SimCardtype.MOB)
            {
                hc.addattack++;
                hc.addHp++;
            }
        }
    }
}