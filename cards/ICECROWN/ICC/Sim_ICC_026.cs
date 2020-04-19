using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_026",
  "name": [
    "冷酷的死灵法师",
    "Grim Necromancer"
  ],
  "text": [
    "<b>战吼：</b>召唤两个1/1的骷髅。",
    "<b>Battlecry:</b> Summon two 1/1 Skeletons."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42438
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_026: SimTemplate //* Grim Necromancer
    {
        // Battlecry: Summon two 1/1 Skeletons.

        SimCard kid = CardIds.NonCollectible.Neutral.GrimNecromancer_SkeletonToken; //1/1 Skeleton

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos - 1, own.own); //1st left
            p.callKid(kid, own.zonepos, own.own);
        }
    }
}