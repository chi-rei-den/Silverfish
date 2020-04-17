using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t14",
  "name": [
    "火山之力",
    "Volcanic Might"
  ],
  "text": [
    "+1/+1",
    "+1/+1"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41691
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t14 : SimCard //* Volcanic Might
	{
		//+1/+1

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 1);
        }
    }
}