using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_035",
  "name": [
    "宴会牧师",
    "Priest of the Feast"
  ],
  "text": [
    "每当你施放一个法术，为你的英雄恢复#3点生命值。",
    "Whenever you cast a spell, restore #3 Health to\nyour hero."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39442
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_035 : SimTemplate //* Priest of the Feast
	{
		//Whenever you cast a spell, restore 3 Health to your hero.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == Chireiden.Silverfish.SimCardtype.SPELL)
            {
				int heal = (wasOwnCard) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
				p.minionGetDamageOrHeal(wasOwnCard ? p.ownHero : p.enemyHero, -heal);
            }
        }
	}
}