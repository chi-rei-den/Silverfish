using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "PART_007",
  "name": [
    "旋风之刃",
    "Whirling Blades"
  ],
  "text": [
    "使一个随从获得+1攻击力。",
    "Give a minion +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2150
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_PART_007 : SimCard //Whirling Blades
    {

        //Give a minion +1 Attack.   


        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 0);
        }


    }

}