using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_096",
  "name": [
    "载人收割机",
    "Piloted Shredder"
  ],
  "text": [
    "<b>亡语：</b>随机召唤一个法力值消耗为（2）的随从。",
    "<b>Deathrattle:</b> Summon a random 2-Cost minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2064
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_096 : SimTemplate //* Piloted Shredder
    {

        // Deathrattle: Summon a random 2-Cost minion.

        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Neutral.BloodfenRaptor;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
        }
    }
}