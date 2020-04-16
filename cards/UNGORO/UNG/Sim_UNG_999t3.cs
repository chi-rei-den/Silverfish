using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t3",
  "name": [
    "烈焰利爪",
    "Flaming Claws"
  ],
  "text": [
    "+3攻击力",
    "+3 Attack"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41058
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t3 : SimTemplate //* Flaming Claws
	{
		//+3 Attack

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
        }
    }
}