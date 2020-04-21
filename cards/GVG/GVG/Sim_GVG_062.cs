using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_062",
  "name": [
    "钴制卫士",
    "Cobalt Guardian"
  ],
  "text": [
    "每当你召唤一个机械，便获得<b>圣盾</b>。",
    "Whenever you summon a Mech, gain <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2030
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_062 : SimTemplate //Cobalt Guardian
    {

        //   Whenever you summon a Mech, gain Divine Shield.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own==summonedMinion.own && summonedMinion.handcard.card.Race == Race.MECHANICAL)
            {
                triggerEffectMinion.divineshild = true;
            }
        }
    }

}