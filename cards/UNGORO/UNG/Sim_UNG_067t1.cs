using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_067t1",
  "name": [
    "水晶核心",
    "Crystal Core"
  ],
  "text": [
    "在本局对战的剩余时间内，你的所有随从变为4/4。",
    "For the rest of the game, your minions are 4/4."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41221
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_067t1 : SimCard //* Crystal Core
	{
		//For the rest of the game, your minions are 5/5.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.ownCrystalCore = 5;
                foreach (Minion m in p.ownMinions)
                {
                    p.minionSetAngrToX(m, 5);
                    p.minionSetLifetoX(m, 5);
                }

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    hc.addattack = 5 - hc.card.Attack;
                    hc.addHp += 5 - hc.card.Health;
                }
            }
        }
    }
}