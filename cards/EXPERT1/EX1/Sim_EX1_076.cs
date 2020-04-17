using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_076",
  "name": [
    "小个子召唤师",
    "Pint-Sized Summoner"
  ],
  "text": [
    "你每个回合使用的第一张随从牌的法力值消耗减少（1）点。",
    "The first minion you play each turn costs (1) less."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 37
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_076 : SimCard //pintsizedsummoner
	{

        //todo enemy stuff
//    der erste diener, den ihr in einem zug ausspielt, kostet (1) weniger.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.winzigebeschwoererin++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.winzigebeschwoererin--;
        }

	}
}