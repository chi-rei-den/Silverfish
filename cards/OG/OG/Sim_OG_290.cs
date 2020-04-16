using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_290",
  "name": [
    "上古之神先驱",
    "Ancient Harbinger"
  ],
  "text": [
    "在你的回合开始时，将一个法力值消耗为（10）的随从从你的牌库置入你的手牌。",
    "At the start of your turn, put a 10-Cost minion from your deck into your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38873
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_290 : SimTemplate //* Ancient Harbinger
	{
		//At the start of your turn, put a 10-Cost minion from your deck into your hand.
		
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
				p.drawACard(CardDB.cardName.varianwrynn, turnStartOfOwner);
            }
        }
	}
}