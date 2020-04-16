using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t4",
  "name": [
    "岩质甲壳",
    "Rocky Carapace"
  ],
  "text": [
    "+3生命值",
    "+3 Health"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41059
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t4 : SimTemplate //* Rocky Carapace
	{
		//+3 Health

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 0, 3);
        }
    }
}