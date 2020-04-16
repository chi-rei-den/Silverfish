using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_007t",
  "name": [
    "诅咒",
    "Cursed!"
  ],
  "text": [
    "如果这张牌在你的手牌中，在你的回合开始时，你的英雄受到2点伤害。",
    "While this is in your hand, take 2 damage at the start of your turn."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 2998
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_007t : SimTemplate //* Cursed!
	{
		//While this is in your hand, take 2 damage at the start of your turn.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, 2, true);
            }
        }
    }
}