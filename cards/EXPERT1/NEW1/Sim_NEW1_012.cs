using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_012",
  "name": [
    "法力浮龙",
    "Mana Wyrm"
  ],
  "text": [
    "每当你施放一个法术，便获得\n+1攻击力。",
    "Whenever you cast a spell, gain +1 Attack."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 405
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_012 : SimTemplate //* Mana Wyrm
	{
		//Whenever you cast a spell, gain +1 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.cardtype.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }
	}
}