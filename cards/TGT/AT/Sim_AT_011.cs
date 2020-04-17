using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_011",
  "name": [
    "神圣勇士",
    "Holy Champion"
  ],
  "text": [
    "每当一个角色获得治疗，便获得\n+2攻击力。",
    "Whenever a character is healed, gain +2 Attack."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2555
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_011 : SimCard //* Holy Champion
	{
		// Whenever a character is healed, gain +2 attack.
        
        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2 * charsGotHealed, 0);
        }
	}
}