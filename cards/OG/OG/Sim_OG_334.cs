using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_334",
  "name": [
    "兜帽侍僧",
    "Hooded Acolyte"
  ],
  "text": [
    "每当一个角色获得治疗时，使你的克苏恩\n获得+1/+1<i>（无论它在哪里）。</i>",
    "Whenever a character is healed, give your\nC'Thun +1/+1 <i>(wherever it is).</i>"
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 39033
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_334 : SimTemplate //* Hooded Acolyte
	{
		// Whenever a character is healed, give your C'Thun +1/+1 (wherever it is)

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            p.cthunGetBuffed(charsGotHealed, charsGotHealed, 0);
        }
	}
}