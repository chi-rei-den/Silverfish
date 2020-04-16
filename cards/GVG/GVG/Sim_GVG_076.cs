using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_076",
  "name": [
    "自爆绵羊",
    "Explosive Sheep"
  ],
  "text": [
    "<b>亡语：</b>对所有随从造成2点伤害。",
    "<b>Deathrattle:</b> Deal 2 damage to all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2044
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_076 : SimTemplate //Explosive Sheep
    {

        //  Deathrattle: Deal 2 damage to all minions. 

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(2);
        }


    }

}