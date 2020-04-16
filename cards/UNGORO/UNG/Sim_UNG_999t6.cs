using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t6",
  "name": [
    "巨型体态",
    "Massive"
  ],
  "text": [
    "<b>嘲讽</b>",
    "<b>Taunt</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41061
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t6 : SimTemplate //* Massive
	{
		//Taunt

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}