using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_018",
  "name": [
    "痛苦女王",
    "Queen of Pain"
  ],
  "text": [
    "<b>吸血</b>",
    "<b>Lifesteal</b>"
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2172
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_018 : SimTemplate //* Mistress of Pain
    {
        // Whenever this minion deals damage, restore that much Health to your hero.
        //done in triggerAMinionDealedDmg (Playfield)
    }
}