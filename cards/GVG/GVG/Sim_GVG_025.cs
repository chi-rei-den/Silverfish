using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_025",
  "name": [
    "独眼欺诈者",
    "One-eyed Cheat"
  ],
  "text": [
    "每当你召唤一个海盗，便获得<b>潜行</b>。",
    "Whenever you summon a Pirate, gain <b>Stealth</b>."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1990
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_025 : SimTemplate //One-eyed Cheat
    {

        //    Whenever you summon a Pirate, gain Stealth.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((Race)summonedMinion.handcard.card.Race == Race.PIRATE)
            {
                triggerEffectMinion.stealth = true;
            }
        }


    }

}