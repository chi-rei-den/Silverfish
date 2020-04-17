using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_103",
  "name": [
    "生长孢子",
    "Evolving Spores"
  ],
  "text": [
    "<b>进化</b>你所有的随从。",
    "<b>Adapt</b> your minions."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 40991
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_103 : SimCard //* Evolving Spores
	{
		//Adapt your minions.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
			bool first = true;
			int bestAdapt = 0;
            foreach (Minion m in temp)
            {
				if (first )
				{
					bestAdapt = p.getBestAdapt(m);
					first = false;
				}
				else
				{
					switch (bestAdapt )
                    {
                        case 1: p.minionGetBuffed(m, 1, 1); break;
                        case 2: p.minionGetBuffed(m, 3, 0); break;
                        case 3: p.minionGetBuffed(m, 0, 3); break;
                        case 4: m.taunt = true; break;
                        case 5: m.divineshild = true; break;
                        case 6: m.poisonous = true; break;
					}
				}				
            }
        }
    }
}