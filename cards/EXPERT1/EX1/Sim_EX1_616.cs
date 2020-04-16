using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_616",
  "name": [
    "法力怨魂",
    "Mana Wraith"
  ],
  "text": [
    "召唤所有随从的法力值消耗增加（1）点。",
    "ALL minions cost (1) more."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 715
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_616 : SimTemplate //manawraith
	{

//    alle diener kosten (1) mehr.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.managespenst ++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.managespenst--;
        }

	}
}