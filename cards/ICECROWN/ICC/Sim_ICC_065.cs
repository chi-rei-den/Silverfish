using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_065",
  "name": [
    "白骨大亨",
    "Bone Baron"
  ],
  "text": [
    "<b>亡语：</b>\n将两张1/1的“骷髅”置入你的手牌。",
    "<b>Deathrattle:</b> Add two 1/1 Skeletons to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42712
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_065: SimTemplate //* Bone Baron
    {
        // Deathrattle: Add two 1/1 Skeletons to your hand.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.GrimNecromancer_SkeletonToken, m.own, true); //Skeleton 1/1
            p.drawACard(CardIds.NonCollectible.Neutral.GrimNecromancer_SkeletonToken, m.own, true);
        }
    }
}