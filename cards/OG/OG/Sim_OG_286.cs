using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_286",
  "name": [
    "暮光尊者",
    "Twilight Elder"
  ],
  "text": [
    "在你的回合结束时，使你的克苏恩\n获得+1/+1<i>（无论它在哪里）。</i>",
    "At the end of your turn, give your C'Thun +1/+1 <i>(wherever it is).</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38868
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_286 : SimTemplate //* Twilight Elder
	{
		//At the end of your turn, give your C'Thun +1/+1 (wherever it is).
		
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (triggerEffectMinion.own) p.cthunGetBuffed(1, 1, 0);
            }
        }
	}
}