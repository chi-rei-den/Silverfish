using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t5",
  "name": [
    "液态外膜",
    "Liquid Membrane"
  ],
  "text": [
    "无法成为法术或英雄技能的\n目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41060
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_999t5 : SimTemplate //* Liquid Membrane
	{
		//Can't be targeted by spells or Hero Powers.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.cantBeTargetedBySpellsOrHeroPowers = true;
        }
    }
}