using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_025",
  "name": [
    "机械幼龙技工",
    "Dragonling Mechanic"
  ],
  "text": [
    "<b>战吼：</b>召唤一个2/1的机械幼龙。",
    "<b>Battlecry:</b> Summon a 2/1 Mechanical Dragonling."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 523
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_025 : SimTemplate//dragonling mechanic
    {
        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.DragonlingMechanic_MechanicalDragonlingToken;//mechanicaldragonling

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos, own.own);
        }

    }
}
