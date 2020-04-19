using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_025",
  "name": [
    "骷髅捣蛋鬼",
    "Rattling Rascal"
  ],
  "text": [
    "<b>战吼：</b>召唤一个5/5的骷髅。\n<b>亡语：</b>为你的对手召唤一个5/5的骷髅。",
    "[x]<b>Battlecry:</b> Summon a\n5/5 Skeleton.\n<b>Deathrattle:</b> Summon one\nfor your opponent."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42422
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_025: SimTemplate //* Rattling Rascal
    {
        // Battlecry: Summon a 5/5 Skeleton. Deathrattle: Summon a 5/5 Skeleton for your opponent.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.SkeletonHeroic; //Skeleton 5/5

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(kid, m.zonepos, m.own);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int pos = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !m.own);
        }
    }
}