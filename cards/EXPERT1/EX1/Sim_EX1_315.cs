using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_315",
  "name": [
    "召唤传送门",
    "Summoning Portal"
  ],
  "text": [
    "你的随从牌的法力值消耗减少（2）点，但不能少于（1）点。",
    "Your minions cost (2) less, but not less than (1)."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 969
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_315 : SimCard //summoningportal
	{

//    eure diener kosten (2) weniger, aber nicht weniger als (1).
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.beschwoerungsportal++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.beschwoerungsportal--;
        }


	}
}