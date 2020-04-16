using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PART_005",
  "name": [
    "紧急冷冻剂",
    "Emergency Coolant"
  ],
  "text": [
    "<b>冻结</b>一个随从。",
    "<b>Freeze</b> a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2155
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_005 : SimTemplate //* Emergency Coolant
    {
        //Freeze a minion. 

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetFrozen(target);
        }
    }
}