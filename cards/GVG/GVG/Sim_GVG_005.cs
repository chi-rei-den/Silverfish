using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_005",
  "name": [
    "麦迪文的残影",
    "Echo of Medivh"
  ],
  "text": [
    "复制你的所有随从，并将其置入你的手牌。",
    "Put a copy of each friendly minion into your hand."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1941
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_005 : SimTemplate //Echo of Medivh
    {

        //    Put a copy of each friendly minion into your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // optimistic
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                p.drawACard(m.handcard.card.CardId, ownplay, true);
            }
            
        }


    }

}