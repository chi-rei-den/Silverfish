using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_006",
  "name": [
    "机械跃迁者",
    "Mechwarper"
  ],
  "text": [
    "你的机械的法力值消耗减少（1）点。",
    "Your Mechs cost (1) less."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1940
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_006 : SimCard //Mechwarper
    {

        //    Your Mechs cost (1) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnMechwarper++;
            }
            else
            {
                p.anzEnemyMechwarper++;

            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnMechwarper--;
            }
            else
            {
                p.anzEnemyMechwarper--;
            }
        }


    }

}