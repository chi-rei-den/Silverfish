using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_051",
  "name": [
    "战斗机器人",
    "Warbot"
  ],
  "text": [
    "受伤时具有+1攻\n击力。",
    "Has +1 Attack while damaged."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2019
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_051 : SimTemplate //Warbot
    {

        //   Enrage:&lt;/b&gt; +1 Attack.

        public override void onEnrageStart(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 1, 0);
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, -1, 0);
        }


    }

}