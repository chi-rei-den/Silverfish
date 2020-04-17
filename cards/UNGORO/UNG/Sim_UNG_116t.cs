using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_116t",
  "name": [
    "“践踏者”班纳布斯",
    "Barnabus the Stomper"
  ],
  "text": [
    "<b>战吼：</b>使你牌库中所有随从的法力值消耗变为（0）点。",
    "<b>Battlecry:</b> Reduce the\nCost of minions in your deck to (0)."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41100
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_116t : SimCard //* Barnabus the Stomper
	{
		//Battlecry: Reduce the Cost of minions in your deck to (0).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownMinionsInDeckCost0 = true;
        }
    }
}