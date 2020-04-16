using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_035",
  "name": [
    "玛洛恩",
    "Malorne"
  ],
  "text": [
    "<b>亡语：</b>将该随从洗入你的牌库。",
    "<b>Deathrattle:</b> Shuffle this minion into your deck."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2003
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_035 : SimTemplate //Malorne
    {

        //    Deathrattle:&lt;/b&gt; Shuffle this minion into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownDeckSize++;
            }
            else
            {
                p.enemyDeckSize++;
            }
        }


    }

}