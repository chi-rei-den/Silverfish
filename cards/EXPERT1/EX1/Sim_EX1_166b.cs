using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_166b",
  "name": [
    "禁魔",
    "Dispel"
  ],
  "text": [
    "<b>沉默</b>一个随从。",
    "<b>Silence</b> a minion."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 321
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_166b : SimCard //dispel
	{

//    bringt einen diener zum schweigen/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
                p.minionGetSilenced(target);
		}

	}
}