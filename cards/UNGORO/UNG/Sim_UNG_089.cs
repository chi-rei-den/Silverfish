using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_089",
  "name": [
    "温顺的巨壳龙",
    "Gentle Megasaur"
  ],
  "text": [
    "<b>战吼：</b><b>进化</b>你所有的鱼人。",
    "<b>Battlecry:</b> <b>Adapt</b> your Murlocs."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41265
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_089 : SimTemplate //* Gentle Megasaur
	{
		//Battlecry: Adapt your Murlocs.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
			bool first = true;
			int bestAdapt = 0;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC)
				{
					if (first )
					{
						bestAdapt = p.getBestAdapt(m);
						first = false;
					}
					else
					{
						switch (bestAdapt)
						{
                            case 1: p.minionGetBuffed(m, 1, 1); break;
                            case 2: p.minionGetBuffed(m, 3, 0); break;
							case 3 : p.minionGetBuffed(m, 0, 3); break;
							case 4 : m.taunt = true; break;
							case 5 : m.divineshild = true; break;
							case 6 : m.poisonous = true; break;
						}
					}
				}
            }
        }
    }
}