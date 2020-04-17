using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_240",
  "name": [
    "符文熔铸游魂",
    "Runeforge Haunter"
  ],
  "text": [
    "在你的回合时，你的武器不会失去\n耐久度。",
    "During your turn, your weapon doesn't lose Durability."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42819
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_240: SimCard //* Runeforge Haunter
    {
        // During your turn, your weapon doesn't lose Durability.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownWeapon.immune = true;
            else p.enemyWeapon.immune = true;
        }

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (turnStartOfOwner) p.ownWeapon.immune = true;
                else p.enemyWeapon.immune = true;
            }
        }
    }
}