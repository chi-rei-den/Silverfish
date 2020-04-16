using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_852",
  "name": [
    "泰拉图斯",
    "Tyrantus"
  ],
  "text": [
    "无法成为法术或英雄技能的目标。",
    "Can't be targeted by spells or Hero Powers."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41954
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_852 : SimTemplate //* Tyrantus
	{
		//Can't be targeted by spells or Hero Powers.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            own.cantBeTargetedBySpellsOrHeroPowers = true;
        }
	}
}