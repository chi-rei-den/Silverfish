using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_066",
  "name": [
    "砂槌萨满祭司",
    "Dunemaul Shaman"
  ],
  "text": [
    "<b>风怒，过载：</b>（1）\n50%几率攻击错误的敌人。",
    "<b>Windfury, Overload:</b> (1)\n50% chance to attack the wrong enemy."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2034
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_066 : SimCard //Dunemaul Shaman
    {
        //   Windfury, Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ueberladung++;
        }
    }
}