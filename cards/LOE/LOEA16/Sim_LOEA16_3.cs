using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOEA16_3",
  "name": [
    "能量之光",
    "Lantern of Power"
  ],
  "text": [
    "使一个随从获得+10/+10。",
    "Give a minion +10/+10."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 10,
  "rarity": null,
  "set": "LOE",
  "collectible": null,
  "dbfId": 19614
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOEA16_3 : SimTemplate //* Lantern of Power
	{
		//Give a minion +10/+10.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 10, 10);
        }
    }
}
