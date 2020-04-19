using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_276",
  "name": [
    "苦战傀儡",
    "Blood Warriors"
  ],
  "text": [
    "复制所有受伤的友方随从，并将其置入你的手牌。",
    "Add a copy of each damaged friendly minion to your hand."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38848
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_276 : SimTemplate //* Blood Warriors
	{
		//Add a copy of each damaged friendly minion to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                if (m.wounded) p.drawACard(m.handcard.card.CardId, ownplay, true);
            }
        }
    }
}