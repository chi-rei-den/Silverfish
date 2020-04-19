using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_032b",
  "name": [
    "卡牌赠礼",
    "Gift of Cards"
  ],
  "text": [
    "每个玩家抽一张牌。",
    "Each player draws a card."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2227
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_032b : SimTemplate //Grove Tender
    {

        //    Give each player a Mana Crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {

                p.drawACard(SimCard.None, true);
                p.drawACard(SimCard.None, false);
           
        }


    }

}