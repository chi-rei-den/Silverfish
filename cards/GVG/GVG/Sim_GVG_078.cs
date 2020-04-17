using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_078",
  "name": [
    "机械雪人",
    "Mechanical Yeti"
  ],
  "text": [
    "<b>亡语：</b>使每个玩家获得一个<b>零件</b>。",
    "<b>Deathrattle:</b> Give each player a <b>Spare Part.</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2046
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_078 : SimCard //* Mechanical Yeti
    {

        //   Deathrattle: Give each player a Spare Part

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.armorplating, false, true);
            p.drawACard(CardDB.cardIDEnum.None, true, true);
        }
    }
}