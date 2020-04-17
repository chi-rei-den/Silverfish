using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PART_001",
  "name": [
    "重型护甲",
    "Armor Plating"
  ],
  "text": [
    "使一个随从获得+1生命值。",
    "Give a minion +1 Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2151
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_001 : SimCard //Armor Plating
    {

        //   Give a minion +1 Health.


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 0, 1);
        }


    }

}