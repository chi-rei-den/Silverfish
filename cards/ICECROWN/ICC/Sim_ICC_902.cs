using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_902",
  "name": [
    "摧心者",
    "Mindbreaker"
  ],
  "text": [
    "双方英雄技能均无法使用。",
    "Hero Powers are disabled."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45314
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_902: SimTemplate //* Mindbreaker
    {
        // Hero Powers are disabled.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.ownHeroAblility.manacost = 100;
            p.enemyHeroAblility.manacost = 100;
            p.ownAbilityReady = false;
            p.ownAbilityReady = false;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            bool another = false;
            foreach (Minion m in p.ownMinions)
            {
                if (m.name == CardIds.Collectible.Neutral.Mindbreaker && own.entitiyID != m.entitiyID) another = true;
            }
            if (!another)
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.name == CardIds.Collectible.Neutral.Mindbreaker && own.entitiyID != m.entitiyID) another = true;
                }
            }
            if (!another)
            {
                p.ownHeroAblility.manacost = 2;
                p.enemyHeroAblility.manacost = 2;
                p.ownAbilityReady = true;
                p.ownAbilityReady = true;
            }
        }
    }
}