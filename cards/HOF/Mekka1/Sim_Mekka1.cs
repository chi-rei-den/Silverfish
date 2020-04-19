using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "Mekka1",
  "name": [
    "导航小鸡",
    "Homing Chicken"
  ],
  "text": [
    "在你的回合开始时，消灭该随从，并抽三张牌。",
    "At the start of your turn, destroy this minion and draw 3 cards."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 227
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_Mekka1 : SimTemplate //homingchicken
	{

//    vernichtet zu beginn eures zuges diesen diener und zieht 3 karten.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                p.minionGetDestroyed(triggerEffectMinion);
                p.drawACard(SimCard.None, turnStartOfOwner);
                p.drawACard(SimCard.None, turnStartOfOwner);
                p.drawACard(SimCard.None, turnStartOfOwner);
            }
        }

	}
}