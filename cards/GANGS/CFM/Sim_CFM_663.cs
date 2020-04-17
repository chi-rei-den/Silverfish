using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_663",
  "name": [
    "暗金教恶魔商贩",
    "Kabal Trafficker"
  ],
  "text": [
    "在你的回合结束时，随机将一张恶魔牌置入你的手牌。",
    "[x]At the end of your turn,\nadd a random Demon\nto your hand."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40940
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_663 : SimCard //* Kabal Trafficker
	{
		// At the end of your turn, add a random Demon to your hand.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardDB.cardName.malchezaarsimp, turnEndOfOwner, true);
            }
        }
    }
}