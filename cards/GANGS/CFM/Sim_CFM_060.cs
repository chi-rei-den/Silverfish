using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_060",
  "name": [
    "猩红法力浮龙",
    "Red Mana Wyrm"
  ],
  "text": [
    "每当你施放一个法术，便获得\n+2攻击力。",
    "Whenever you cast a spell, gain +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40281
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_060 : SimCard //* Red Mana Wyrm
	{
		// Whenever you cast a spell, gain +2 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.cardtype.SPELL)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }
    }
}