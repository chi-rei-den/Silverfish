using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_001",
  "name": [
    "圣光护卫者",
    "Lightwarden"
  ],
  "text": [
    "每当一个角色获得治疗，便获得\n+2攻击力。",
    "Whenever a character is healed, gain +2 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1655
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_001 : SimTemplate //* lightwarden
	{
        // Whenever a character is healed, gain +2 Attack.

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2 * charsGotHealed, 0);
        }
	}
}