using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA12_4",
  "name": [
    "龙血之痛：绿",
    "Brood Affliction: Green"
  ],
  "text": [
    "如果这张牌在你的手牌中，在你的回合开始时，敌方英雄恢复#2点生命值。",
    "While this is in your hand, restore #2 health to your opponent at the start of your turn."
  ],
  "CardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2363
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMA12_4 : SimTemplate //* Brood Affliction: Green
	{
		//While this is in your hand, restore 2 health to your opponent at the start of your turn.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, -2, true);
            }
        }
    }
}