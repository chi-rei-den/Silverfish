using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_823",
  "name": [
    "模拟幻影",
    "Simulacrum"
  ],
  "text": [
    "复制你手牌中法力值消耗最低的随从牌。",
    "Copy the lowest Cost minion in your hand."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43193
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_823: SimCard //* Simulacrum
    {
        // Copy the lowest Cost minion in your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                Handmanager.Handcard hcCopy = null;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.type == CardDB.cardtype.MOB)
                    {
                        if (hcCopy == null) hcCopy = hc;
                        else
                        {
                            if (hcCopy.manacost > hc.manacost) hcCopy = hc;
                        }
                    }
                }
                if (hcCopy != null) p.drawACard(hcCopy.card.name, ownplay, true);
            }
        }
    }
}