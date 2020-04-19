using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_213",
  "name": [
    "永恒奴役",
    "Eternal Servitude"
  ],
  "text": [
    "<b>发现</b>一个本局对战中死亡的友方随从，并召唤该随从。",
    "<b>Discover</b> a friendly minion that died this game. Summon it."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42597
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_213: SimTemplate //* Eternal Servitude
    {
        // Discover a friendly minion that died this game. Summon it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.ownMaxMana >= 6)
            {
                int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
                Chireiden.Silverfish.SimCard kid = ((p.OwnLastDiedMinion == Chireiden.Silverfish.SimCard.None) ? CardIds.NonCollectible.Priest.Mindgames_ShadowOfNothingToken : p.OwnLastDiedMinion); // Shadow of Nothing 0:1 or ownMinion
                p.callKid(kid, pos, ownplay, false);
            }
        }
    }
}