using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_807",
  "name": [
    "大富翁比尔杜",
    "Auctionmaster Beardo"
  ],
  "text": [
    "在你施放一个法术后，复原你的\n英雄技能。",
    "After you cast a spell, refresh your Hero Power."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40605
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_807 : SimTemplate //* Auctionmaster Beardo
	{
		// After you cast a spell, refresh your Hero Power.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == Chireiden.Silverfish.SimCardtype.SPELL)
            {
                if (m.own)
                {
                    p.anzUsedOwnHeroPower = 0;
                    p.ownAbilityReady = true;
                }
                else
                {
                    p.anzUsedEnemyHeroPower = 0;
                    p.enemyAbilityReady = true;
                }
            }
        }
    }
}