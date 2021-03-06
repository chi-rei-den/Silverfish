using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_111",
  "name": [
    "米米尔隆的头部",
    "Mimiron's Head"
  ],
  "text": [
    "在你的回合开始时，如果你控制至少三个机械，则消灭这些机械，并将其组合成V-07-TR-0N。",
    "At the start of your turn, if you have at least 3 Mechs, destroy them all and form V-07-TR-0N."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2079
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_111 : SimTemplate //* Mimiron's Head
    {
        //   At the start of your turn, if you have at least 3 Mechs, destroy them all and form V-07-TR-0N.

        SimCard kid = CardIds.NonCollectible.Neutral.MimironsHead_V07Tr0NToken;

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner != triggerEffectMinion.own)
            {
                return;
            }

            var temp = turnStartOfOwner ? p.ownMinions : p.enemyMinions;
            var anz = 0;
            foreach (var m in temp)
            {
                if (m.handcard.card.Race == Race.MECHANICAL && m.Hp >= 1)
                {
                    anz++;
                }
            }

            if (anz >= 3)
            {
                anz = 0;
                foreach (var m in temp)
                {
                    if (m.handcard.card.Race == Race.MECHANICAL)
                    {
                        p.minionGetDestroyed(m);
                        anz++;
                        if (anz == 3)
                        {
                            break;
                        }
                    }
                }

                var pos = triggerEffectMinion.own ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kid, pos, triggerEffectMinion.own, false, true); // we allow to summon one minion more (because 3 are destroyed)
            }
        }
    }
}