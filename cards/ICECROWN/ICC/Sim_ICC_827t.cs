using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_827t",
  "name": [
    "暗影映像",
    "Shadow Reflection"
  ],
  "text": [
    "每当你使用一张牌，变形成为该卡牌的复制。",
    "Each time you play a card, transform this into a copy of it."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 45724
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_827t : SimCard //* Shadow Reflection
    {
        //Each time you play a card, transform this into a copy of it.

        //handled

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            triggerhc.setHCtoHC(hc);
        }
    }
}