using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_032a",
  "name": [
    "水晶赠礼",
    "Gift of Mana"
  ],
  "text": [
    "使每个玩家获得一个法力水晶。",
    "Give each player a Mana Crystal."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2226
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_032a : SimCard //* Grove Tender
    {

        //   Give each player a Mana Crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.mana = Math.Min(10, p.mana+1);
            p.ownMaxMana = Math.Min(10, p.ownMaxMana+1);
            p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
        }


    }

}