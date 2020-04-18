using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_019",
  "name": [
    "骷髅法师",
    "Skelemancer"
  ],
  "text": [
    "<b>亡语：</b>如果此时是你对手的回合，则召唤一个8/8的骷髅。",
    "<b>Deathrattle:</b> If it's your opponent's turn, summon an 8/8 Skeleton."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42328
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_019: SimTemplate //* Skelemancer
    {
        // Deathrattle: If it's your opponent's turn, summon an 8/8 Skeleton.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.Skelemancer_SkeletalFlayerToken; //Skeletal Flayer

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.callKid(kid, m.zonepos, m.own);
        }
    }
}